using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mytracker.Repositories;

public class LocationRepository : ILocationRepository {
    private SQLiteAsyncConnection connection;
    public async Task<List<Microsoft.Maui.Devices.Sensors.Location>> GetAllAsync() {
        await CreateConnectionAsync();
        var locations = await connection.Table<Location>().ToListAsync();
        return locations;
    }

    public async Task SaveAsync(Models.Location location) {
        await CreateConnectionAsync();
        await connection.InsertAsync(location);
    }

    private async Task CreateConnectionAsync() {
        if (connection != null) return;

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Locations.db");

        connection = new SQLiteAsyncConnection(databasePath);
        await connection.CreateTableAsync<Location>();
    }
}
