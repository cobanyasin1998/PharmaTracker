namespace Coban.Persistence.SeedData.Abstractions;

public interface ISeedData
{
    Task<int> SeedEntityData(int count = 5000);
}
