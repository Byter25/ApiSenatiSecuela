using ApiSenatiSecuela.Data;
using Entity;

namespace ApiSenatiSecuela.Bussines
{
    public class AlumnoGradoInstruccionBussines
    {
        private readonly IConfiguration _configuration;
        public AlumnoGradoInstruccionBussines(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<AlumnoDetalle> GetAlumnosDetalle()
        {
            List<AlumnoDetalle> oRetorno = new List<AlumnoDetalle>();
            oRetorno = new AlumnoGradoInstruccionData(_configuration).GetAlumnosDetalle();
            return oRetorno;
        }
        public List<GradoInstruccionAlumnos> GetIdGradoInstruccionAlumno(int id)
        {
            List<GradoInstruccionAlumnos> oRetorno = new List<GradoInstruccionAlumnos>();
            oRetorno = new AlumnoGradoInstruccionData(_configuration).GetIdGradoInstruccionAlumno(id);
            return oRetorno;
        }
    }
}
