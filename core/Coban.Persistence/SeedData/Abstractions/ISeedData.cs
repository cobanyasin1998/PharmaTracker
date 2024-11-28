namespace Coban.Persistence.SeedData.Abstractions;

public interface ISeedData
{
    int SeedEntityData(int count = 5000);
}
