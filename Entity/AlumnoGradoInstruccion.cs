using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlumnoDetalle
    {
        public required int IdAlumno { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required bool AlumnoActivo { get; set; }
        public required int IdGradoInstruccion { get; set; }
        public required string GradoInstruccion { get; set; }
    }

    public class GradoInstruccionAlumnos
    {
        public int GradoInstruccion { get; set; }
        public required string Descripcion { get; set; }
        public int IdAlumno { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public bool AlumnoActivo { get; set; }
    }

}
