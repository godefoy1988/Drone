using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Model.UnitOfWork.Interfaces;
using Drones.Services.Interfaces;

namespace Drones.Services;

public class LoadService : ILoadService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LoadService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Register(LoadViewModel loadView)
    {
        await _unitOfWork.GetLoadRepo().AddAsync(_mapper.Map<Load>(loadView));
        var result = await _unitOfWork.SaveChangesAsync();
        return result != 0;
    }
}

