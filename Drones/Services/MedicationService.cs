using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Services.Interfaces;
using System.Security.Cryptography;

namespace Drones.Services;

public class MedicationService : IMedicationService
{
    private readonly IRepository<Medication> _repository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public MedicationService(IRepository<Medication> repository, IMapper mapper, IWebHostEnvironment environment)
    {
        _repository = repository;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<bool> Register(MedicationViewModel medicationView)
    {
        var (imageName, pathName) = await SaveImage(medicationView.File);
        medicationView.ImageName = imageName;
        medicationView.PathImage = pathName;
        await _repository.AddAsync(_mapper.Map<Medication>(medicationView));
        var result = await _repository.SaveChangesAsync();
        return result != 0;
    }

    private async Task<(string,string)> SaveImage(IFormFile file)
    {
        if (file.Length > 0)
        {
            if (!Directory.Exists(@$"{_environment.ContentRootPath}\Upload"))
            {
                Directory.CreateDirectory(@$"{_environment.ContentRootPath}\Upload");
            }
            var extension = file.FileName.Split(".")[1];
            var autoFileName = $"{Guid.NewGuid()}.{extension}";            
            using (FileStream filestream = File.Create(@$"{_environment.ContentRootPath}\Upload\{autoFileName}"))
            {
                file.CopyTo(filestream);
                filestream.Flush();
                return (file.FileName, autoFileName);
            }
        }
        return default;
    }
}
