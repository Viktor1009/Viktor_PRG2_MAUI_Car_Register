using System.Text.Json;
using PRG_MAUI_Car_Register.model;

namespace PRG_MAUI_Car_Register.service
{
    public class JsonVehicleRegisterService : IVehicleRegisterService
    {
        private readonly string _filePath;

        public JsonVehicleRegisterService()
        {
            _filePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "vehicles.json");
        }

        public async Task SaveAsync(IEnumerable<Vehicle> vehicles)
        {
            var json = JsonSerializer.Serialize(vehicles,
                new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<IList<Vehicle>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Vehicle>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Vehicle>>(json)
                   ?? new List<Vehicle>();
        }
    }
}
