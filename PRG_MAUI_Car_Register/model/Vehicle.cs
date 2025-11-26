namespace PRG_MAUI_Car_Register.model
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
        public abstract string GetDescription();

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
            set { vehicleType = value; }
        }

        public string Model
        {
            get 
            { return model; }
            set 
            {
                if(value != "")
                {
                    foreach (char c in value)
                    {
                        if (!char.IsLetterOrDigit(c))
                        {
                            throw new ArgumentException("En model måste bestå av endast nummer och bokstäver");
                        }
                        else
                        {
                            model = value;
                        }
                    }
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set 
            {
                if(value != "")
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsLetter(value[i]))
                        {
                            throw new ArgumentException("Ett Märke får inte använda sig av tecken utanför alphabetet");
                        }
                        else
                        {
                            manufacturer = value;
                        }
                    }
                }
            }
        }

        public string YearModel
        {
            get { return yearModel; }
            set
            {

                if (int.TryParse(value, out int modelyear))
                {
                    if (modelyear >= 1895 && modelyear <= DateTime.Now.Year)
                    {
                        value = modelyear.ToString();
                    }
                    else
                    {
                        throw new ArgumentException("Du får endast registrera bilar mellan årtalen 1865 och nu");
                    }
                }
                else
                {
                    throw new ArgumentException("Skriv årsmodelen med 4 siffror");
                }
            }
            //throw new ArgumentException("En årsmodel måste bestå endast siffror mellan 0 till 9");
        }
    }
}