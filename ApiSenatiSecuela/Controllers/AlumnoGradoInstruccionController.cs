using ApiSenatiSecuela.Bussines;
using ApiSenatiSecuela.Data;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace ApiSenatiSecuela.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoGradoInstruccionController
    {
        private readonly IConfiguration _configuration;
        public AlumnoGradoInstruccionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getAlumnoDetalle")]
        public List<AlumnoDetalle> GetAlumnosDetalle()
        {
            List<AlumnoDetalle> oRetorno = new List<AlumnoDetalle>();
            oRetorno = new AlumnoGradoInstruccionBussines(_configuration).GetAlumnosDetalle();
            return oRetorno;
        }
        [HttpGet]
        [Route("getIdGradoInstruccionAlumno/{idGradoInstruccion}")]
        public List<GradoInstruccionAlumnos> GetIdGradoInstruccionAlumno(int idGradoInstruccion)
        {
            List<GradoInstruccionAlumnos> oRetorno = new List<GradoInstruccionAlumnos>();
            oRetorno = new AlumnoGradoInstruccionBussines(_configuration).GetIdGradoInstruccionAlumno(idGradoInstruccion);
            return oRetorno;
        }
    }
}
