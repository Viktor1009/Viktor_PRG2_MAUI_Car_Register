    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PRG_MAUI_Car_Register.model;
using PRG_MAUI_Car_Register.service;

namespace PRG_MAUI_Car_Register.viewmodel
{
    class MainPageModelView : INotifyPropertyChanged
    {
        public IList<Vehicle.Type> VehicleTypes { get; } =
        Enum.GetValues(typeof(Vehicle.Type)).Cast<Vehicle.Type>().ToList();

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private readonly IVehicleRegisterService _storage;
        

        // ------------------------------------------------------ Egenskaper av Vehicle
        private string _registrationNumber;
        public string RegistrationNumber
        {
            get => _registrationNumber;
            set { _registrationNumber = value; OnPropertyChanged(); }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;
            set { _manufacturer = value; OnPropertyChanged(); }
        }

        private string _modelName;
        public string ModelName
        {
            get => _modelName;
            set { _modelName = value; OnPropertyChanged(); }
        }

        private string _yearModel;
        public string YearModel
        {
            get => _yearModel;
            set { _yearModel = value; OnPropertyChanged(); }
        }

        private Vehicle.Type _selectedType = Vehicle.Type.Car; // sätter deafult type till Car
        public Vehicle.Type SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value; OnPropertyChanged();
            }
        }   

        public ObservableCollection<Vehicle> Vehicles => VehicleService.Instance.VehicleItems;
        
// ---------------------------------------------- Söker
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private string _searchResult;
        public string SearchResult
        {
            get => _searchResult;
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand SearchCommand { get; }

        public ICommand SaveCommand { get; }

        public MainPageModelView()
        {
            _storage = new JsonVehicleRegisterService();

            Debug.WriteLine("Debug 1: " + _storage); // funkar inte ???

            RegisterCommand = new Command(RegisterVehicle);
            SearchCommand = new Command(SearchVehicle);

            
            SaveCommand = new Command(async () => await SaveAsync());
            _ = LoadAsync();
            
        }
        
        private async Task LoadAsync()
        {
            var vehicles = await _storage.LoadAsync();
            Vehicles.Clear();

            foreach (var vehicle in vehicles)
                Vehicles.Add(vehicle);
        }

        private async Task SaveAsync()
        { 
            
            await _storage.SaveAsync(Vehicles);
        }
        

        private void RegisterVehicle() 
        {
            Vehicle vehicle;

            switch (SelectedType) // assignar typen av vehicle
            {
                case Vehicle.Type.Car:
                    vehicle = new Car();
                    break;

                case Vehicle.Type.Motorcycle:
                    vehicle = new Motorcycle();
                    break;

                case Vehicle.Type.Truck:
                    vehicle = new Truck();
                    break;

                default:
                    throw new ArgumentException("Välj en giltig fordonstyp.");
                    
            }
            vehicle.RegistrationNumber = RegistrationNumber;
            vehicle.Manufacturer = Manufacturer;
            vehicle.ModelName = ModelName;
            vehicle.YearModel = YearModel;

            VehicleService.Instance.VehicleItems.Add(vehicle);

            ClearEntryFields();
        }

        private void SearchVehicle()
        {
            var q = SearchQuery?.Trim() ?? "";

            var result = Vehicles.FirstOrDefault(v => // letar fram det registreringsnummer som matchar närmast 
                !string.IsNullOrEmpty(v.RegistrationNumber) &&
                v.RegistrationNumber.Contains(q, StringComparison.OrdinalIgnoreCase));

            SearchResult = result == null
                ? "No Vehicle Found"
                : $"{result.RegistrationNumber} {result.Manufacturer} {result.ModelName} ({result.YearModel})";
        }

        private void ClearEntryFields() // QOL metod
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            ModelName = string.Empty;
            YearModel = string.Empty;
        }
    }
}
