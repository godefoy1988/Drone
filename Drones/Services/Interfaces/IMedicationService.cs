namespace Drones.Services.Interfaces
{
    public interface IMedicationService
    {
        Task<int> Register(MedicationViewModel medicationView);
    }
}
