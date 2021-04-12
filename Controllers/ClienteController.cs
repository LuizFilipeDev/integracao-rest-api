using System.Collections.Generic;
using ProjetoIntegracao.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ProjetoIntegracao.Controllers
{
    public class ClienteController : Controller
    {
        #region Cliente
        public ActionResult Index(){
            
            return View();
        }
        
        public JsonResult Selecionar_Clientes(){

            List<Cliente.Retorno> cliente = new List<Cliente.Retorno>();
            string clienteJson = string.Empty;

            cliente = Cliente.SelecionarTodos();

            clienteJson = JsonConvert.SerializeObject(cliente);

            return Json(clienteJson);
        }
        #endregion

        #region Cliente Editar
        public ActionResult ClienteEditar(){

            Cliente.Retorno cliente = new Cliente.Retorno();

            if(RouteData.Values["id"] != null){
                cliente = Models.Cliente.Selecionar(RouteData.Values["id"].ToString());
            }

            return View(cliente);
        }
        public string ClienteSelecionar_Editar(string Identificador, Cliente.Envio Cliente)
        {
            string retorno = string.Empty;

            if (string.IsNullOrEmpty(Identificador))
            {

                retorno = HUB.integracao.PostCliente(Cliente);

            }
            else
            {

                HUB.integracao.PutCliente(Cliente, Identificador);
                retorno = "existe";

            }
            return retorno;
        }
        public string Cliente_Deletar(string Identificador)
        {
            string retorno = HUB.integracao.DeleteCliente(Identificador);

            return retorno;
        }
        #endregion
    }
}