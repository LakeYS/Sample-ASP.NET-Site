using System;
using System.Collections.Generic;
using Sample_ASP.NET_Site.Models;

namespace Sample_ASP.NET_Site.DAL
{
    public interface IManagerRepository : IDisposable
    {
        Client GetClientByID(int clientId);
        void InsertClient(Client client);
        void DeleteClient(int clientID);
        void UpdateClient(Client client);
        void Save();
    }
}