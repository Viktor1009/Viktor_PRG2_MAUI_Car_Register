using PRG_MAUI_Car_Register.viewmodel;
using PRG_MAUI_Car_Register.model;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            if (entryManufacturer.Text != "" && entryModel.Text != "")
            {
                try
                {
                    Car car = new Car();
                    Truck truck = new Truck();
                    Motorcycle motorcycle = new Motorcycle();

                    // Skapa rätt class beroende på vad man valde i pickerType
                    switch ((Vehicle.Type)pickerType.SelectedIndex)
                    {
                        case Vehicle.Type.Bil:
                            {
                                car = new Car();
                                car.RegistrationNumber = entryRegistrationNumber.Text;
                                car.Manufacturer = entryManufacturer.Text;
                                car.Model = entryModel.Text;
                                car.YearModel = entryYearModel.Text;

                                vehicleList.Add(car);
                                listViewVehicles.ItemsSource = null;
                                listViewVehicles.ItemsSource = vehicleList;
                                break;
                            }
                        case Vehicle.Type.MC:
                            {
                                motorcycle = new Motorcycle();
                                motorcycle.RegistrationNumber = entryRegistrationNumber.Text;
                                motorcycle.Manufacturer = entryManufacturer.Text;
                                motorcycle.Model = entryModel.Text;
                                motorcycle.YearModel = entryYearModel.Text;

                                vehicleList.Add(motorcycle);
                                listViewVehicles.ItemsSource = null;
                                listViewVehicles.ItemsSource = vehicleList;
                                break;
                            }
                        case Vehicle.Type.Lastbil:
                            {
                                truck = new Truck();
                                truck.RegistrationNumber = entryRegistrationNumber.Text;
                                truck.Manufacturer = entryManufacturer.Text;
                                truck.Model = entryModel.Text;
                                truck.YearModel = entryYearModel.Text;

                                vehicleList.Add(truck);
                                listViewVehicles.ItemsSource = null;
                                listViewVehicles.ItemsSource = vehicleList;
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException("Välj en giltig fordonstyp.");
                            }
                            
                    }

                    entryRegistrationNumber.Text = string.Empty;
                    entryManufacturer.Text = string.Empty;
                    entryModel.Text = string.Empty;
                    entryYearModel.Text = string.Empty;
                }
                catch (ArgumentException ex)
                {
                    DisplayAlert("Fel", ex.Message, "OK");
                }
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            // Skapa en filtrerad lista baserat på vilken radioknapp som är vald
            List<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Bil).ToList();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.MC).ToList();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Lastbil).ToList();
            }
            else
            {
                // Om "Alla" är vald, visa hela listan
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Typ: {foundVehicle.VehicleType}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

    }
}
