namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
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

        //TODOne Tillverkare ska valideras, sparas i objektet och visas i UI
        public string Model
        {
            get 
            { return model; }
            set 
            {
                this.model = value.ToLower();
                if (this.manufacturer == "Volvo")
                {
                    if (this.model == "xc60" || this.model == "ex30" || this.model == "ex40")
                    {
                        model = this.model.ToUpper();
                    }
                    else
                    {
                        throw new ArgumentException("De enda giltliga modelerna för Volvo i vårt register är en av: \nXC60 \nEX30 \nEX40");
                    }
                }
                else if (this.manufacturer == "Kia")
                {
                    if (this.model == "pv5 cargo" || this.model == "pv5 crew" || this.model == "pv5 passenger")
                    {
                        model = this.model.ToUpper();
                    }
                    else
                    {
                        throw new ArgumentException("De enda giltliga bilarna i vårt för Kia i vårt register är en av: \nPV5 CARGO \nPV5 CREW \nPV5 PASSENGER");
                    }
                }
                else if (this.manufacturer == "Ford")
                {
                    if (this.model == "transit courier" || this.model == "transit connect" || this.model == "transit custom")
                    {
                        model = this.model.ToUpper();
                    }
                    else
                    {
                        throw new ArgumentException("De enda giltliga bilarna i vårt för Ford i vårt register är en av: \nTRANSIT COURIER \nTRANSIT CONNECT \nTRANSIT CUSTOM");
                    }
                }
                else
                {
                    throw new ArgumentException("De enda giltliga bilarna i vårt register är en av: \nVolvo \nKia \nFord");
                }
            }
        }

        //TODOne Modell ska valideras, sparas i objektet och visas i UI
        public string Manufacturer
        {
            get { return manufacturer; }
            set 
            { 
                // Scrapped Code
                //this.manufacturer = value;
                //this.manufacturer = value.ToLower();
                //if (this.manufacturer == "volvo" || this.manufacturer == "kia" || this.manufacturer == "ford")
                //{
                //    //value = value.ToUpper(char[0]); // Provade detta, det funkar ej
                //    manufacturer = char.ToUpper(this.manufacturer[0]) + this.manufacturer.Substring(1);
                //}
                //else
                //{
                //    throw new ArgumentException("De enda giltliga bilarna i vårt register är en av: \nVolvo \nKia \nFord");
                //}

               if //Is Letter
            }
        }

        //TODO Att spara årsmodell ska möjliggöras, ska valideras, sparas i objektet och visas i UI
        public string YearModel
        {
            get { return yearModel; }
            set
            {
                //Scrapped Code
                //string invalidYearModel = "\"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\\\"#$%&'()*+,-./:;<=>?@[\\\\]^_`{|}~ \"";
                //foreach(char c in this.yearModel)
                //{
                //    if (!invalidYearModel.Contains(c))
                //    {
                //    }
                //    else
                //    {
                //    }
                
                if // isDigit
            }
        }

        // Klassens  eventuella övriga metoder brukar finnas här, här en override av ToString()

        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model + "\t" +this.yearModel;
        }
    }
}
