using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PRG_MAUI_Car_Register.model;
using PRG_MAUI_Car_Register.viewmodel;

class TruckViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string n = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    public ObservableCollection<Vehicle> Trucks { get; }
        = new ObservableCollection<Vehicle>();

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

    public ICommand SearchCommand { get; }

    public TruckViewModel()
    {
        // Hämtar in listan på alla lastbilar
        LoadTruck();

        SearchCommand = new Command(SearchTruck); // när knappen med SearchCommand trycks körs SearchTruck functionen
    }

    private void LoadTruck()
    {
        Trucks.Clear();
        foreach (var v in VehicleService.Instance.VehicleItems
                     .Where(v => v.VehicleType == Vehicle.Type.Truck))
            Trucks.Add(v);
    }

    private void SearchTruck()
    {
        var q = SearchQuery?.Trim() ?? "";

        var result = Trucks.FirstOrDefault(v =>
            !string.IsNullOrEmpty(v.RegistrationNumber) &&
            v.RegistrationNumber.Contains(q, StringComparison.OrdinalIgnoreCase));

        SearchResult = result == null
            ? "Not found."
            : $"{result.RegistrationNumber} {result.Manufacturer} {result.Model} ({result.YearModel})";
    }
}
