using System.Collections.ObjectModel;
using gallery_app.Models;

namespace gallery_app.Services;

public partial class PhotoImporter : IPhotoImporter {
    private Task<string[]> Import(); 
    public Task<ObservableCollection<Photo>> Get(int start, int count, Quality quality) {
        throw new NotImplementedException();
    }

    public Task<ObservableCollection<Photo>> Get(List<string> filenames, Quality quality) {
        throw new NotImplementedException();
    }
}
