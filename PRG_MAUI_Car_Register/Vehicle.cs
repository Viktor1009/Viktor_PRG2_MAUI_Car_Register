namespace PRG_MAUI_Car_Register
{
    abstract class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        protected Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        public string Model
        {
            get 
            { return model; }
            set 
            {
                #region Felaktig Lösning
                //this.model = value.ToLower();
                //if (this.manufacturer == "Volvo")
                //{
                //    if (this.model == "xc60" || this.model == "ex30" || this.model == "ex40")
                //    {
                //        model = this.model.ToUpper();
                //    }
                //    else
                //    {
                //        throw new ArgumentException("De enda giltliga modelerna för Volvo i vårt register är en av: \nXC60 \nEX30 \nEX40");
                //    }
                //}
                //else if (this.manufacturer == "Kia")
                //{
                //    if (this.model == "pv5 cargo" || this.model == "pv5 crew" || this.model == "pv5 passenger")
                //    {
                //        model = this.model.ToUpper();
                //    }
                //    else
                //    {
                //        throw new ArgumentException("De enda giltliga bilarna i vårt för Kia i vårt register är en av: \nPV5 CARGO \nPV5 CREW \nPV5 PASSENGER");
                //    }
                //}
                //else if (this.manufacturer == "Ford")
                //{
                //    if (this.model == "transit courier" || this.model == "transit connect" || this.model == "transit custom")
                //    {
                //        model = this.model.ToUpper();
                //    }
                //    else
                //    {
                //        throw new ArgumentException("De enda giltliga bilarna i vårt för Ford i vårt register är en av: \nTRANSIT COURIER \nTRANSIT CONNECT \nTRANSIT CUSTOM");
                //    }
                //}
                //else
                //{
                //    throw new ArgumentException("De enda giltliga bilarna i vårt register är en av: \nVolvo \nKia \nFord");
                //}
                #endregion
                // en änding jag ska göra i framtiden är ta bort if (invalidYearModel.Contains(c)) och istället använda
                // value.All(char.IsLetterOrDigit) en funktion som jag inte tidigare visste fanns
                string invalidYearModel = "\"!\\\"#$%&'()*+,-./:;<=>?@[\\\\]^_`{|}~ \"";
                foreach (char c in value)
                {
                    if (invalidYearModel.Contains(c)) 
                    {
                        throw new ArgumentException("En model måste bestå av endast nummer och bokstäver");
                    }
                    else 
                    {
                        this.model = value;
                    }
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set 
            {
                #region Scrapped Code

                //this.manufacturer = value.ToLower();
                //if (this.manufacturer == "volvo" || this.manufacturer == "kia" || this.manufacturer == "ford")
                //    manufacturer = char.ToUpper(this.manufacturer[0]) + this.manufacturer.Substring(1); }
                //else { throw new ArgumentException("De enda giltliga bilarna i vårt register är en av: \nVolvo \nKia \nFord"); }
                #endregion

                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        throw new ArgumentException("Ett Märke får inte använda sig av tecken utanför alphabetet");
                    }
                    else
                    {
                        this.manufacturer = value;
                    }
                }
            }
        }

        public string YearModel
        {
            get { return yearModel; }
            set
            {
                #region Scrapped Code
                //string invalidYearModel = "\"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\\\"#$%&'()*+,-./:;<=>?@[\\\\]^_`{|}~ \"";
                //foreach(char c in this.yearModel) {
                //    if (!invalidYearModel.Contains(c)) {}
                //    else{} }
                #endregion

                if (value.Length == 4)
                {
                    if (value[0] != '1' && value[0] != '2')
                    {
                        throw new ArgumentException("Första tecknet i årsmodelen måste vara 1 eller 2.");
                    }
                    for (int i = 1; i < value.Length; i++)
                    {
                        if (!char.IsDigit(value[i]))
                        {
                            throw new ArgumentException("De sista tre tecknen i årsmodelen måste vara siffror.");
                        }
                            
                    }
                }
                else
                {
                    throw new ArgumentException("Skriv årsmodelen med 4 siffror");
                }
                yearModel = value;
            }
            //throw new ArgumentException("En årsmodel måste bestå endast siffror mellan 0 till 9");
        }

        // Klassens  eventuella övriga metoder brukar finnas här, här en override av ToString()

        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model + "\t" +this.yearModel;
        }
    }

    class Car : Vehicle
    {
        public Car() : base(Type.Bil)
        {

        }
    }
    class Motorcycle : Vehicle
    {
        public Motorcycle() : base(Type.MC)
        {

        }
    }
    class Truck : Vehicle
    {
        public Truck() : base(Type.Lastbil)
        {

        }
    }
}