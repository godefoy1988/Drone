using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork.Interfaces;
using Drones.Services.Interfaces;
using System.Security.Cryptography;

namespace Drones.Services;

public class MedicationService : IMedicationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public MedicationService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _environment = environment;
    }

    public async Task<int> Register(MedicationViewModel medicationView)
    {
        var (imageName, pathName) = await SaveImage(medicationView.File);
        medicationView.ImageName = imageName;
        medicationView.PathImage = pathName;
        var medicationEntity = _mapper.Map<Medication>(medicationView);
        await _unitOfWork.GetMedicationRepo().AddAsync(medicationEntity);
        await _unitOfWork.SaveChangesAsync();
        return medicationEntity.Id;
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
