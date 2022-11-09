using System;
using Lab4.Models;

namespace Lab4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MarketDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
            new Client{FirstName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("1995-01-09")},
            new Client{FirstName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("1992-09-05")},
            new Client{FirstName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("1993-10-09")},
            new Client{FirstName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("1992-01-09")},
            };
            foreach (Client s in clients)
            {
                context.Clients.Add(s);
            }
            context.SaveChanges();

            var brokerages = new Broker[]
            {
            new Broker{Id="A1",Title="Alpha",Fee=300},
            new Broker{Id="B1",Title="Beta",Fee=130},
            new Broker{Id="O1",Title="Omega",Fee=390},
            };
            foreach (Broker c in brokerages)
            {
                context.Brokers.Add(c);
            }
            context.SaveChanges();

            var subscriptions = new Subscription[]
            {
            new Subscription{ClientId=1,BrokerId="A1"},
            new Subscription{ClientId=1,BrokerId="B1"},
            new Subscription{ClientId=1,BrokerId="O1"},
            new Subscription{ClientId=2,BrokerId="A1"},
            new Subscription{ClientId=2,BrokerId="B1"},
            new Subscription{ClientId=3,BrokerId="A1"},
            };
            foreach (var subscription in subscriptions)
            {
                context.Subscriptions.Add(subscription);
            }
            context.SaveChanges();

	    }
	}
}

