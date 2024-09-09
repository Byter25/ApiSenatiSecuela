using ApiSenatiSecuela.Bussines;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSenatiSecuela.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlumnoController : ControllerBase
    {
        private readonly ILogger<AlumnoController> _logger;
        private readonly IConfiguration _configuration;
        public AlumnoController(ILogger<AlumnoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("consultarAlumno")]
        public List<Alumno> GetConsultaAlumno() 
        {
            List<Alumno> oRetorno = new List<Alumno>();
            try
            {
                AlumnoBussines oAlumnoBussines = new AlumnoBussines(_configuration);
                oRetorno = oAlumnoBussines.ConsultarAlumno();
            }
            catch (Exception ex) 
            { 
                oRetorno = new List<Alumno>();
                Console.WriteLine(ex.Message);
                throw;
            }
            return oRetorno;
        }

        [HttpGet]
        [Route("DeleteAlumno/{IdAlumno}")]
        public bool GetConsultaAlumno(int IdAlumno)
        {
            bool oRetorno = true;
            try
            {
                AlumnoBussines oAlumnoBussines = new AlumnoBussines(_configuration);
                oRetorno = oAlumnoBussines.EliminarAlumno(IdAlumno);
            }
            catch (Exception ex)
            {
                throw;
            }
            return oRetorno;
        }
    }
}
