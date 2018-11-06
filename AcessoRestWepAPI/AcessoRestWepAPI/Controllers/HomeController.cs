using DatabaseLib;
using RegrasNegocio;
using RegrasNegocio.Models;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;

namespace AcessoRestWepAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public string CalcularAumento()
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

        public string AlterarStatus([FromBody]Status status)
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

        private IDbAccess CriaAccess()
        {
            return new DbAccess(new SqlConnection("Server=localhost\\MSSQLSERVER2014;Database=TESTEUNITARIO;Trusted_Connection=True; user id =rm;password=rm"));
        }
    }

}
