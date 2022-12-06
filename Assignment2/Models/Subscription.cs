using System;

namespace Assignment2.Models
{
    public class Subscription
    {

        public int ClientId
        {
            get;
            set;
        }

        public string BrokerId
        {
            get;
            set;
        }

        public Client Client {
            get;
            set;
        }

        public Broker Broker {
            get;
            set;
        }
    }
}

