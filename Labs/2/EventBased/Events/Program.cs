namespace Events {

    class Program {
        static void Main() {

            EventList pub = new EventList();
            Subscriber sub = new Subscriber(pub) { Name = "Opty" };

            pub.Add(new Product {
                Name = "Name1",
                Price = 10
            });
            pub.Add(new Product {
                Name = "Name2",
                Price = 20
            });

            pub[0] = pub[1];
            pub.Clear();

            sub.UnsubscribePub();

            pub.Add(new Product {
                Name = "Name3",
                Price = 30
            });
        }
    }
}
