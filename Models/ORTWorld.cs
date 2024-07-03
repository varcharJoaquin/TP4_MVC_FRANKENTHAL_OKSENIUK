public static class ORTWorld
    {
        public static List<string> ListaHoteles {get; private set;} = new List<string>{"Tunkelen", "Sheraton", "Alvear Palace", "The Hat", "Woohoo"};
        public static List<string> ListaDestinos {get; private set;} = new List<string> {"Cordoba", "Londres", "Denver", "Abu Dhabi", "París", "Machu Picchu ", "CDMX", "Sucre", "Oslo", "Sydney"};
        public static List<string> ListaExcursiones {get; private set;} = new List<string> {"Cordoba.jpg", "Londres.jpg", "Denver.jpg", "AbuDhabi.jpg", "Paris.jpg", "MachuPicchu.jpg", "CDMX.jpg", "Sucre.jpg", "Oslo.jpg", "Sydney.jpg"};
        public static List<string> ListaAereos {get; private set;} = new List<string> {"Lufthansa.jpg", "Iberia.jpg", "Flybondi.jpg", "Emirates.jpg","Gol.jpg" };
        public static Dictionary<string, Paquete> Paquetes {get; private set;} = new Dictionary<string, Paquete> {};

        public static bool ingresarPaquete(string destinoIngresado, Paquete paquete) 
        {
            bool encuentra = Paquetes.ContainsKey(destinoIngresado);
            if (!encuentra)
            {
                Paquetes.Add(destinoIngresado, paquete);
            }
            return encuentra;
        }
    }