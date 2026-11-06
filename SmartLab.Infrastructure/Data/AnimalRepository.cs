using Microsoft.EntityFrameworkCore;
using SmartLab.Domain.Entities;
using SmartLab.Domain.Repositories;

namespace SmartLab.Infrastructure.Data;

public class AnimalRepository : IAnimalRepository
{
    private readonly SmartLabDbContext _context;

    public AnimalRepository(SmartLabDbContext context)
    {
        _context = context;
    }

    public async Task<Animal?> GetByIdAsync(int id)
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Include(a => a.Father)
            .Include(a => a.Mother)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Include(a => a.Father)
            .Include(a => a.Mother)
            .ToListAsync();
    }

    public async Task AddAsync(Animal animal)
    {
        await _context.Animals.AddAsync(animal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Animal animal)
    {
        _context.Animals.Update(animal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal != null)
        {
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Animal>> GetByStrainIdAsync(int strainId)
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Where(a => a.StrainId == strainId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Animal>> GetByCageIdAsync(int cageId)
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Where(a => a.CageId == cageId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Animal>> GetByFatherIdAsync(int fatherId)
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Include(a => a.Father)
            .Include(a => a.Mother)
            .Where(a => a.FatherId == fatherId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Animal>> GetByMotherIdAsync(int motherId)
    {
        return await _context.Animals
            .Include(a => a.Strain)
            .Include(a => a.Cage)
            .Include(a => a.Father)
            .Include(a => a.Mother)
            .Where(a => a.MotherId == motherId)
            .ToListAsync();
    }
}