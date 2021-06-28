using System.Collections.Generic;
using Service;
using Domain;
using System.Web.Http;
using System.Web.Http.Results;
using APIFactura.Models;
using APIFactura.Repository;

namespace APIFactura.Controllers
{
    public class ClientController : ApiController
    {
        ClientService Service;
        public ClientController()
        {
            Service = new ClientService();
        }

        // GET: Client
        [HttpGet]
        public JsonResult<List<ClientModel>> GetAllClients()
        {
            EntityMapper<Client, ClientModel> mapObj = new EntityMapper<Client, ClientModel>();
            List<Client> cliList = Service.Get();
            List<ClientModel> Clients = new List<ClientModel>();
            foreach (var item in cliList)
            {
                Clients.Add(mapObj.Translate(item));
            }
            return Json<List<ClientModel>>(Clients);
        }

        [HttpGet]
        public JsonResult<ClientModel> GetClient(int id)
        {
            EntityMapper<Client, ClientModel> mapObj = new EntityMapper<Client, ClientModel>();
            Client oneClient = Service.GetById(id);
            ClientModel Clients = new ClientModel();
            Clients = mapObj.Translate(oneClient);
            return Json<ClientModel>(Clients);
        }
    }
}