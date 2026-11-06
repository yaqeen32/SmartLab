using Microsoft.AspNetCore.Mvc;
using SmartLab.Domain.Enums;
using SmartLab.Domain.Entities;
using SmartLab.Domain.Repositories;
using SmartLab.Application.DTOs;

namespace SmartLab.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _repository;

    public AnimalsController(IAnimalRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
    {
        var animals = await _repository.GetAllAsync();
        var dtos = animals.Select(a => new AnimalDto
        {
            Id = a.Id,
            UniqueId = a.UniqueId,
            Sex = a.Sex,
            Status = a.Status,
            BirthDate = a.BirthDate,
            Weight = a.Weight,
            StrainId = a.StrainId,
            StrainName = a.Strain.Name,
            CageId = a.CageId,
            CageName = a.Cage.Name,
            FatherId = a.FatherId,
            MotherId = a.MotherId,
        });

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalDto>> GetAnimal(int id)
    {
        var animal = await _repository.GetByIdAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        var dto = new AnimalDto
        {
            Id = animal.Id,
            UniqueId = animal.UniqueId,
            Sex = animal.Sex,
            Status = animal.Status,
            BirthDate = animal.BirthDate,
            Weight = animal.Weight,
            StrainId = animal.StrainId,
            StrainName = animal.Strain.Name,
            CageId = animal.CageId,
            CageName = animal.Cage.Name,
            FatherId = animal.FatherId,
            MotherId = animal.MotherId,
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<AnimalDto>> CreateAnimal(CreateAnimalRequest request)
    {
        var animal = new Animal
        {
            UniqueId = GenerateUniqueId(),
            Sex = request.Sex,
            Status = AnimalStatus.Active,
            BirthDate = request.BirthDate,
            Weight = request.Weight,
            StrainId = request.StrainId,
            CageId = request.CageId,
            FatherId = request.FatherId,
            MotherId = request.MotherId,
        };

        await _repository.AddAsync(animal);

        var dto = new AnimalDto
        {
            Id = animal.Id,
            UniqueId = animal.UniqueId,
            Sex = animal.Sex,
            Status = animal.Status,
            BirthDate = animal.BirthDate,
            Weight = animal.Weight,
            StrainId = animal.StrainId,
            StrainName = animal.Strain.Name,
            CageId = animal.CageId,
            CageName = animal.Cage.Name,
            FatherId = animal.FatherId,
            MotherId = animal.MotherId,
        };

        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnimal(int id, UpdateAnimalRequest request)
    {
        var animal = await _repository.GetByIdAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        animal.Sex = request.Sex;
        animal.Status = request.Status;
        animal.BirthDate = request.BirthDate;
        animal.Weight = request.Weight;
        animal.StrainId = request.StrainId;
        animal.CageId = request.CageId;
        animal.FatherId = request.FatherId;
        animal.MotherId = request.MotherId;

        await _repository.UpdateAsync(animal);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        var animal = await _repository.GetByIdAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);

        return NoContent();
    }

    private string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString()[..8];
    }
}

public class CreateAnimalRequest
{
    public AnimalSex Sex { get; set; }
    public AnimalStatus Status { get; set; } = AnimalStatus.Active;
    public DateTime BirthDate { get; set; }
    public double Weight { get; set; }
    public int StrainId { get; set; }
    public int CageId { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
}

public class UpdateAnimalRequest
{
    public AnimalSex Sex { get; set; }
    public AnimalStatus Status { get; set; }
    public DateTime BirthDate { get; set; }
    public double Weight { get; set; }
    public int StrainId { get; set; }
    public int CageId { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
}