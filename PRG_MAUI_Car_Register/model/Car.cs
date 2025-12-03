using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.model
{
    class Car : Vehicle
    {
        public override string GetDescription()
        {
            return "This is a car, it usually has 4 wheels and 4 doors. It's an essential part of the modern world.";
        }
        public Car() : base(Type.Car)
        {
            
        }

    }
}
