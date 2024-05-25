using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace labfinal.data.data_acces
{
    internal class datos
    {
        public int id { get; set; }
        public string nombreconsola { get; set; }
        public string compañia { get; set; }
        public DateTime fechalanzamiento{ get; set; }
        public int generaciones { get; set; }
        //constructor sin parametros

        public datos() { }

        // Constructor con parámetros
        public datos(int id, string nombreconsola, string compañia, DateTime fechalanzamiento, int generacion)
        {
            id = id;
            nombreconsola = nombreconsola;
            compañia = compañia;
            fechalanzamiento = fechalanzamiento;
            generacion = generacion;
          
        }
        public int Obtenefehcadesalida()
        {
            int fecha = DateTime.Now.Year - fechalanzamiento.Year;
            if (DateTime.Now.DayOfYear < fechalanzamiento.DayOfYear)
            {
                fecha--;
            }
            return fecha;
        }
        //mostrar informacion de la consola 

        public override string ToString()
        {
            return $"id_consola: {id}, Nombreconsola: {nombreconsola} {generaciones}, Fecha de Nacimiento: {fechalanzamiento.ToShortDateString()}";
        }

    }
}
