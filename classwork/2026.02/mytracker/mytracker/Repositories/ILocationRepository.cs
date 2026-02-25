using System;
using System.Collections.Generic;
using System.Text;

namespace mytracker.Repositories;

public interface ILocationRepository {
    Task<List<Location>> GetAllAsync();
    Task SaveAsync(Models.Location location);
}
