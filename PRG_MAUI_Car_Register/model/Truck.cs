using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.model
{
    class Truck : Vehicle
    {
        public override string GetDescription()
        {
            return "This is a Truck, it's usually big and heavy. Sometimes made for offroading.";
        }
        public Truck() : base(Type.Truck)
        {

        }
    }
}
