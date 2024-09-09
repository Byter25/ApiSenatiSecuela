using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int IdGradoInstruccion { get; set; }
        public GradoInstruccion GradoInstruccion { get; set; }
        public bool Enabled { get; set; }
    }

    public class AlumnoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int IdGradoInstruccion { get; set; }
        public bool Enabled { get; set; }
    }
}

