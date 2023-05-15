namespace Drones.Services.Interfaces
{
    public interface IMedicationService
    {
        Task<bool> Register(MedicationViewModel medicationView);
    }
}
