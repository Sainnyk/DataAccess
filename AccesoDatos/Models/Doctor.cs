using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Doctor
    {
        public int IdHospital { get; set; }
        public int IdDoctor { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
