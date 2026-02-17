using System.Collections.ObjectModel;
using gallery_app.Models;

namespace gallery_app.Services;

public interface IPhotoImporter {
    public Task<ObservableCollection<Photo>> Get(int start, int count, Quality quality = Quality.Low);
    public Task<ObservableCollection<Photo>> Get(List<string> filenames, Quality quality = Quality.Low);
}
