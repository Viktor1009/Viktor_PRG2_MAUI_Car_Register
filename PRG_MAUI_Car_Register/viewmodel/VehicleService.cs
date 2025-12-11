using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static System.Reflection.Metadata.BlobBuilder;
using PRG_MAUI_Car_Register.model;
namespace PRG_MAUI_Car_Register.viewmodel
{
    class VehicleService
    {
        private static VehicleService _instance;
        public static VehicleService Instance => _instance ??= new VehicleService();

        public ObservableCollection<Vehicle> VehicleItems { get; set; }

        private VehicleService()
        {
            VehicleItems = new ObservableCollection<Vehicle>();
                   
        }
    }

}
