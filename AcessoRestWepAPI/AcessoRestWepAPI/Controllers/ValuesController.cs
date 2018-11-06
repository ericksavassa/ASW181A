using DatabaseLib;
using Newtonsoft.Json;
using RegrasNegocio;
using RegrasNegocio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcessoRestWepAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post()
        {
            string logCalculo = string.Empty;
            using (var persistencia = new PersistenciaFuncionario(CriaAccess(), new LogWriter()))
            {
                var calculoAumento = new CalculaAumentoFuncionario(persistencia, new LogWriter(), new LogWriter());
                calculoAumento.Calcula();
                logCalculo = calculoAumento.Log;
            }
            return logCalculo;
        }

        // PUT api/values/5
        [HttpPut]
        public string Put(int id, [FromBody]Status status)
        {
            string logCalculo = string.Empty;
            using (var persistencia = new PersistenciaFuncionario(CriaAccess(), new LogWriter()))
            {
                var alteraStatus = new AlteraStatusFuncionario(persistencia, new LogWriter(), new LogWriter());
                alteraStatus.AlteraStatus(status.IdFuncionario, status.StatusFuncionario);
                logCalculo = alteraStatus.Log;
            }
            return logCalculo;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        private IDbAccess CriaAccess()
        {
            return new DbAccess(new SqlConnection("Server=localhost\\MSSQLSERVER2014;Database=TESTEUNITARIO;Trusted_Connection=True;user id=rm;password=rm;"));
        }
    }
}
