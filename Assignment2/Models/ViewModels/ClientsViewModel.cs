using System;
using Assignment2.Models;

namespace Assignment2.Models.ViewModels
{
    public class ClientsViewModel
    {
        public IEnumerable<Client> Clients {get; set; }
        public IEnumerable<Subscription> Subscriptions {get; set; }

    }
}

