using CsvHelper;
using System.Globalization;
namespace GestionRiesgos
{
    class Program{
        public static string ruta = "riesgos.csv";
        //main
        static void Main(string[] args)
        {
            //Crear lista de riesgos
            //List<Riesgo> riesgos = new List<Riesgo>();
            //Menu
            while(true){
                Console.WriteLine("1. Agregar riesgo");
                Console.WriteLine("2. Eliminar riesgo");
                Console.WriteLine("3. Modificar riesgo");
                Console.WriteLine("4. Mostrar riesgos");
                Console.WriteLine("5. Exportar riesgos a CSV");
                Console.WriteLine("6. Importar riesgos de CSV");
                Console.WriteLine("7. Salir");
                Console.WriteLine("Ingrese una opcion: ");
                string opcion = Console.ReadLine();
                switch(opcion){
                    case "1":
                        CrearRiesgo();
                        break;
                    case "2":
                        EliminarRiesgo();
                        break;
                    case "3":
                        ModificarRiesgo();
                        break;
                    case "4":
                        MostrarRiesgos();
                        break;
                    case "5":
                        ExportarRiesgos();
                        break;
                    case "6":
                        ImportarRiesgos();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }



        }

        public static void EliminarRiesgo(){
            Console.WriteLine("Ingrese el id del riesgo que desea eliminar");
            int id = int.Parse(Console.ReadLine());
            List<Riesgo> riesgos = CargarArchivoCSV(ruta);
            foreach(Riesgo riesgo in riesgos){
                if(riesgo.id == id){
                    riesgos.Remove(riesgo);
                    break;
                }
            }
            //ordenar riesgos por magnitud de mayor a menor
            riesgos = ordenarRiesgos(riesgos);
            CrearArchivoCSV(ruta, riesgos);
        }

        public static void ImportarRiesgos(){
            Console.WriteLine("Ingrese el nombre del archivo CSV");
            string nombre = Console.ReadLine();
            List<Riesgo> riesgos = CargarArchivoCSV(nombre);
            CrearArchivoCSV(ruta, riesgos);
        }

        public static void ExportarRiesgos(){
            List<Riesgo> riesgos = CargarArchivoCSV(ruta);
            riesgos = ordenarRiesgos(riesgos);
            CrearArchivoCSV(ruta, riesgos);
        }
        public static void MostrarRiesgos(){
            //sort riesgos by magnitud
            List<Riesgo> riesgos = CargarArchivoCSV(ruta);
            //sort riesgos by magnitud de menor a mayor
            riesgos = ordenarRiesgos(riesgos);
            CrearArchivoCSV(ruta, riesgos);
            imprimirRiesgos(riesgos);
        }

        public static List<Riesgo> ordenarRiesgos(List<Riesgo> riesgos){
            riesgos.Sort((x, y) => y.magnitud.CompareTo(x.magnitud));
            return riesgos;
        }

        public static void ModificarRiesgo(){
            Console.WriteLine("Ingrese el id del riesgo que desea modificar");
            int id = int.Parse(Console.ReadLine());
            List<Riesgo> riesgos = CargarArchivoCSV(ruta);
            foreach(Riesgo riesgo in riesgos){
                if(riesgo.id == id){
                    //select variable to modify
                    Console.WriteLine("1. Nombre");
                    Console.WriteLine("2. Probabilidad");
                    Console.WriteLine("3. Impacto");
                    Console.WriteLine("4. Plan de mitigación");
                    Console.WriteLine("5. Plan de monitoreo");
                    Console.WriteLine("6. Plan de contingencia");
                    Console.WriteLine("Ingrese una opcion: ");
                    string opcion = Console.ReadLine();
                    switch(opcion){
                        case "1":
                            Console.WriteLine("Ingrese el nuevo nombre");
                            string nombre = Console.ReadLine();
                            riesgo.nombre = nombre;
                            break;
                        case "2":
                            Console.WriteLine("Ingrese la nueva probabilidad");
                            string probabilidad = Console.ReadLine();
                            riesgo.probabilidad = probabilidad;
                            riesgo.magnitud = ObtenerMagnitud(probabilidad, riesgo.impacto);
                            break;
                        case "3":
                            Console.WriteLine("Ingrese el nuevo impacto");
                            string impacto = Console.ReadLine();
                            riesgo.impacto = impacto;
                            Console.WriteLine("Probabilidad: "+riesgo.probabilidad);
                            Console.WriteLine("Nuevo impacto: "+ impacto);
                            riesgo.magnitud = ObtenerMagnitud(riesgo.probabilidad, impacto);
                            Console.WriteLine("Nueva magnitud: "+riesgo.magnitud);
                            break;
                        case "4":
                            Console.WriteLine("Ingrese el nuevo plan de mitigación");
                            string planMitigacion = Console.ReadLine();
                            riesgo.planes[0].descripcion = planMitigacion;
                            break;
                        case "5":
                            Console.WriteLine("Ingrese el nuevo plan de monitoreo");
                            string planMonitoreo = Console.ReadLine();
                            riesgo.planes[1].descripcion = planMonitoreo;
                            break;
                        case "6":
                            Console.WriteLine("Ingrese el nuevo plan de contingencia");
                            string planContingencia = Console.ReadLine();
                            riesgo.planes[2].descripcion = planContingencia;
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                    ;break;
                }
            }
            riesgos = ordenarRiesgos(riesgos);
            CrearArchivoCSV(ruta, riesgos);
        }
        public static void CrearRiesgo(){
            List<Riesgo> riesgos = CargarArchivoCSV(ruta);
            //obtener el id mas alto en la lista riesgos
            int i = obtenerIdMax(riesgos);
            while(true){
                Console.WriteLine("Escriba el nombre del riesgo");
                string nombre = Console.ReadLine();
                Console.WriteLine("Escriba la probabilidad del riesgo:");
                Console.WriteLine("Poco probable = 0, Posible = 1, Probable = 2, Muy probable = 3");
                string probabilidad = Console.ReadLine();
                switch(probabilidad){
                    case "0":
                        probabilidad = "Poco probable";
                        break;
                    case "1":
                        probabilidad = "Posible";
                        break;
                    case "2":
                        probabilidad = "Probable";
                        break;
                    case "3":
                        probabilidad = "Muy probable";
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.WriteLine("Escriba el impacto del riesgo");
                Console.WriteLine("Marginal = 0, Moderado = 1, Crítico = 2, Catastrófico = 3");
                string impacto = Console.ReadLine();
                switch(impacto){
                    case "0":
                        impacto = "Marginal";
                        break;
                    case "1":
                        impacto = "Moderado";
                        break;
                    case "2":
                        impacto = "Crítico";
                        break;
                    case "3":
                        impacto = "Catastrófico";
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                string magnitud = ObtenerMagnitud(probabilidad, impacto);
                Console.WriteLine("Escriba el plan de mitigación del riesgo");
                string pMitigacion = Console.ReadLine();
                Console.WriteLine("Escriba el plan de monitoreo del riesgo");
                string pMonitoreo = Console.ReadLine();
                Console.WriteLine("Escriba el plan de contingencia del riesgo");
                string pContingencia = Console.ReadLine();
                Console.WriteLine("Plan agregado con éxito");
                Riesgo riesgo = new Riesgo(i, nombre, probabilidad, impacto, magnitud, new List<Plan>());
                riesgo.planes.Add(new Plan(1, pMitigacion));
                riesgo.planes.Add(new Plan(2, pMonitoreo));
                riesgo.planes.Add(new Plan(3, pContingencia));
                riesgos.Add(riesgo);
                Console.WriteLine("Desea agregar otro riesgo? (s/n)");
                string respuesta = Console.ReadLine();
                if(respuesta == "s"){
                    i++;
                }else{
                    break;
                }
            }
            riesgos = ordenarRiesgos(riesgos);
            CrearArchivoCSV(ruta, riesgos);
            //return riesgos;
        }

        public static int obtenerIdMax(List<Riesgo> riesgos){
            int idMax = 0;
            foreach(Riesgo riesgo in riesgos){
                if(riesgo.id > idMax){
                    idMax = riesgo.id;
                }
            }
            idMax++;
            return idMax;
        }

        public static string ObtenerMagnitud(string probabilidad, string impacto){
            string magnitud = "";
            probabilidad = probabilidad.ToLower();
            impacto = impacto.ToLower();
            //baja = 0, media = 1, alta = 2, muy alta = 3
            if(probabilidad == "muy probable" && impacto == "catastrófico"){
                magnitud = "3";
            }else if(probabilidad == "muy probable" && impacto == "crítico"){
                magnitud = "2";
            }else if(probabilidad == "muy probable" && impacto == "moderado"){
                magnitud = "2";
            }else if(probabilidad == "muy probable" && impacto == "marginal"){
                magnitud = "1";
            }else if(probabilidad == "probable" && impacto == "catastrófico"){
                magnitud = "2";
            }else if(probabilidad == "probable" && impacto == "crítico"){
                magnitud = "2";
            }else if(probabilidad == "probable" && impacto == "moderado"){
                magnitud = "1";
            }else if(probabilidad == "probable" && impacto == "marginal"){
                magnitud = "1";
            }else if(probabilidad == "posible" && impacto == "catastrófico"){
                magnitud = "2";
            }else if(probabilidad == "posible" && impacto == "crítico"){
                magnitud = "1";
            }else if(probabilidad == "posible" && impacto == "moderado"){
                magnitud = "1";
            }else if(probabilidad == "posible" && impacto == "marginal"){
                magnitud = "0";
            }else if(probabilidad == "poco probable" && impacto == "catastrófico"){
                magnitud = "1";
            }else if(probabilidad == "poco probable" && impacto == "crítico"){
                magnitud = "1";
            }else if(probabilidad == "poco probable" && impacto == "moderado"){
                magnitud = "0";
            }else if(probabilidad == "poco probable" && impacto == "marginal"){
                magnitud = "0";
            }
            return magnitud;
        }
        public static void CrearArchivoCSV(string ruta, List<Riesgo> riesgos){
            using(var writer = new StreamWriter(ruta))
                using(var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach(Riesgo r in riesgos)
                    {
                        csv.WriteField(r.id);
                        csv.WriteField(r.nombre);
                        csv.WriteField(r.probabilidad);
                        csv.WriteField(r.impacto);
                        csv.WriteField(r.magnitud);
                        foreach(Plan p in r.planes)
                        {
                            //csv.WriteField(p.id);
                            csv.WriteField(p.descripcion);
                        }
                        csv.NextRecord();
                    }
                }
        }

        public static void imprimirRiesgos(List<Riesgo> riesgos)
        {
            foreach(Riesgo r in riesgos)
            {
                Console.WriteLine(r.id);
                Console.WriteLine(r.nombre);
                Console.WriteLine(r.probabilidad);
                Console.WriteLine(r.impacto);
                Console.WriteLine(r.magnitud);
                foreach(Plan p in r.planes)
                {
                    Console.WriteLine(p.descripcion);
                }
                Console.WriteLine();
            }
        }

        public static List<Riesgo> CargarArchivoCSV(string ruta)
        {
            List<Riesgo> riesgos = new List<Riesgo>();
            using(var reader = new StreamReader(ruta))
            {
                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        while(csv.Read())
                        {
                            List<Plan> planes = new List<Plan>();
                            for(int i = 1, j = 5; j < 8; j++, i++)
                                planes.Add(new Plan(i, csv.GetField<string>(j)));
                            Riesgo riesgo = new Riesgo(csv.GetField<int>(0), csv.GetField<string>(1), csv.GetField<string>(2), csv.GetField<string>(3), csv.GetField<string>(4), planes);
                            riesgos.Add(riesgo);
                        }
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                        
                }
            }
            riesgos = ordenarRiesgos(riesgos);
            return riesgos; 
        }
    }
}