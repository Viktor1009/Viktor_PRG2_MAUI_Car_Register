using PRG_MAUI_Car_Register.model;

namespace PRG_MAUI_Car_Register.service
{
    // poängen med detta interface är att vi enkelt ska kunna byta Json till något annat, som SQLite
    public interface IVehicleRegisterService
    {
        Task SaveAsync(IEnumerable<Vehicle> vehicles);

        Task<IList<Vehicle>> LoadAsync();
    }
}