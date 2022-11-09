using System;
using Lab4.Models;

namespace Lab4.Models.ViewModels
{
    public class BrokeragesViewModel
    {
        public IEnumerable<Client> Clients {get; set; }
        public IEnumerable<Broker> Brokers {get; set; }
        public IEnumerable<Subscription> Subscriptions {get; set; }

    }
}

