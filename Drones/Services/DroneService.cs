using AutoMapper;
using Drones.Model.Repository.Interface;
using Drones.Services.Interfaces;

namespace Drones.Services
{
    public class DroneService : IDroneService
    {
        private readonly IRepository<Drone> _repository;
        private readonly IMapper _mapper;

        public DroneService(IRepository<Drone> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Register(DroneViewModel droneView)
        {
            await _repository.AddAsync(_mapper.Map<Drone>(droneView));
            var result = await _repository.SaveChangesAsync();
            return result != 0;
        }
    }
}
