namespace GestionRiesgos
{
    class Riesgo
    {
        
        public int id { get; set; }	//id del riesgo
        public string nombre { get; set; }	//nombre del riesgo 
        public string probabilidad { get; set; }	//probabilidad del riesgo
        public string impacto { get; set; }	//impacto del riesgo
        public string magnitud { get; set; }	//magnitud del riesgo
        public List<Plan> planes = new List<Plan>() {};	//lista de planes del riesgo
        public Riesgo(int id, string nombre, string probabilidad, string impacto, string magnitud, List<Plan> planes)
        {
            this.id = id;
            this.nombre = nombre;
            this.probabilidad = probabilidad;
            this.impacto = impacto;
            this.magnitud = magnitud;
            this.planes = planes;
        }      
    }
}