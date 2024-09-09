using Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiSenatiSecuela.Data
{
    public class GradoInstruccionData
    {
        private readonly IConfiguration _configuration;
        public GradoInstruccionData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
