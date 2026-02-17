using System.Collections.ObjectModel;
using gallery_app.Models;

namespace gallery_app.Services;

public interface IPhotoImporter {
    Task<ObservableCollection<Photo>> Get(int start, int count, Quality )
}
