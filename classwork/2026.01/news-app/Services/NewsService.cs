using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using news_app.Models;

namespace news_app.Services {
    public class NewsService : INewsService, IDisposable {
        private bool disposedValue;
        private const string UriBase = "https://newsapi.org/v2";
        private readonly HttpClient httpClient = new() {
            BaseAddress = new(UriBase),
            DefaultRequestHeaders = { { "user-agent", "maui-projects-news/1.0" } },
        };
        
        public async Task<NewsResult> GetNews(NewsScope scope) {
            NewsResult result;
            string url = GetUrl(scope);

            try {
                result = await httpClient.GetFromJsonAsync<NewsResult>(url);
            } catch (Exception ex) {
                result = new() { 
                    Articles = new() { 
                        new() { 
                            Title = $"HTTP Get failed:{ex.Message}", 
                            PublishedAt = DateTime.Now
                        }
                    } 
                };
            }

            return result;
        }

        private string GetUrl(NewsScope scope) => scope switch {
            NewsScope.Headlines => Headlines,
            NewsScope.Local => Local,
            NewsScope.Global => Global,
            _ => throw new Exception("Undefined scope")
        };

        private static string Headlines => $"{UriBase}/top-headlines?country=us&apiKey={Settings.NewsApiKey}";
        private static string Local => $"{UriBase}/everything?q=local&apiKey={Settings.NewsApiKey}";
        private static string Global => $"{UriBase}/everything?q=global&apiKey={Settings.NewsApiKey}";

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    httpClient.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
