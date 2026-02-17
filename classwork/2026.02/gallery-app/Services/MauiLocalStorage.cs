
using System.Text.Json;

namespace gallery_app.Services;

public class MauiLocalStorage : ILocalStorage {
    public const string FavouritePhotosKey = "FavoiuritePhotos";
    public List<string> Get() {
        if (Preferences.ContainsKey(FavouritePhotosKey)) {
            var filenames = Preferences.Get(FavouritePhotosKey, string.Empty);
            return JsonSerializer.Deserialize<List<string>>(filenames);
        }

        return new List<string>();
    }

    public void Store(string filename) {
        var filenames = Get();
        filenames.Add(filename);

        var json = JsonSerializer.Serialize(filenames);

        Preferences.Set(FavouritePhotosKey, json);
    }
}
