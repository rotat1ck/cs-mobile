using System;
using System.Collections.Generic;
using System.Text;
using news_app.Models;

namespace news_app.Services {
    public interface INewsService {
        public Task<NewsResult> GetNews(NewsScope scope);
    }
}
