using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Departamento
    {
        //ESTA CLASE TENDRA TODAS LAS COLUMNAS De LA TABLE CON SUS TIPOS DE DATOS.
        //Lo necesitamos porque en los metodos de repositorio no puedes crear un método que devuelva varios tipos de datos diferente.(EJEMPLO MAL: public int,string MostrarDept(int id))
        //Como son propiedades con get y set, van en mayusuclas
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
    }
}
