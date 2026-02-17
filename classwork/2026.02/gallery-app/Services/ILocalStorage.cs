namespace gallery_app.Services;

public interface ILocalStorage {
    void Store(string fileName);
    List<string> Get();
}
