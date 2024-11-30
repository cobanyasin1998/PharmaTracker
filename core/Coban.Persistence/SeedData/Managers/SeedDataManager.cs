﻿using Coban.Persistence.SeedData.Abstractions;

namespace Coban.Persistence.SeedData.Managers;

public class SeedDataManager
{
    private readonly IEnumerable<ISeedData> _seedDataServices;

    public SeedDataManager(IEnumerable<ISeedData> seedDataServices)
    {
        _seedDataServices = seedDataServices;
    }

    public void SeedAll(int count = 5000)
    {
        foreach (var seedService in _seedDataServices)
        {
            _ = seedService.SeedEntityData(count);
        }
    }
}
