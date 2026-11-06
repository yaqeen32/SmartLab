using SmartLab.Domain.Entities;

namespace SmartLab.Domain.Repositories;

public interface IAnimalRepository
{
    Task<Animal?> GetByIdAsync(int id);
    Task<IEnumerable<Animal>> GetAllAsync();
    Task AddAsync(Animal animal);
    Task UpdateAsync(Animal animal);
    Task DeleteAsync(int id);
    Task<IEnumerable<Animal>> GetByStrainIdAsync(int strainId);
    Task<IEnumerable<Animal>> GetByCageIdAsync(int cageId);
    Task<IEnumerable<Animal>> GetByFatherIdAsync(int fatherId);
    Task<IEnumerable<Animal>> GetByMotherIdAsync(int motherId);
}