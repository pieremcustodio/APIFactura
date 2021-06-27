using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
    public class ClientService
    {
        public List<Client> Get()
        {
            List<Client> clients = null;
            using (var context = new InvoiceContext())
            {
                clients = context.Client.ToList();
            }
            return clients;
        }

        public Client GetById(int ID)
        {
            Client client = null;
            using (var context = new InvoiceContext())
            {
                client = context.Client.Find(ID);
            }
            return client;
        }
    }
}
