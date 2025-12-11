using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.model
{
    class Motorcycle : Vehicle
    {
        public override string GetDescription()
        {
            return "This is a Motorcycle, it usually has two wheels. Cool people always ride motorcycles";
        }
        public Motorcycle() : base(Type.Motorcycle)
        {

        }
        public override string ToString() // ser till att resultatet när man hämtar vehicle listan ser rätt ut
        {
            return $"{RegistrationNumber} {Manufacturer} {Model} {YearModel} - Motorcycle";
        }
    }
}
