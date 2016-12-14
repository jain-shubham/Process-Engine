using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;

namespace Engine
{
    class BasicExample
    {
        public static void execute()
        {
            var Address = new
            {
                Street = "123 Tornado Alley\nSuite 16",
                City = "East Westville",
                State = "KS"
            };

            var receipt = new
            {
                Receipt = "Oz-Ware Purchase Invoice",
                Date = new DateTime(2007, 8, 6),
                Customer = new
                {
                    Given = "Dorothy",
                    Family = "Gale"
                },
                Items = new[]
                {
                    new
                    {
                        part_no = "A4786",
                        Descrip = "Water Bucket (Filled)",
                        Price = 1.47M,
                        Quantity = 4
                    },
                    new
                    {
                        part_no = "E1628",
                        Descrip = "High Heeled \"Ruby\" Slippers",
                        Price = 100.27M,
                        Quantity = 1
                    }
                },
                bill_to = Address,
                ship_to = Address,
                SpecialDelivery = "Follow the Yellow Brick\n" +
                                  "Road to the Emerald City.\n" +
                                  "Pay no attention to the\n" +
                                  "man behind the curtain."
            };

            var serializer = new Serializer();
            string Document = serializer.Serialize(receipt);

            var input = new StringReader(Document);

            var deserializer = new Deserializer();

            Order order = (Order)deserializer.Deserialize(input, typeof(Order));

            Console.WriteLine("Order");
            Console.WriteLine("-----");
            Console.WriteLine();
            foreach (var item in order.Items)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", item.PartNo, item.Quantity, item.Price, item.Descrip);
            }
            Console.WriteLine();

            Console.WriteLine("Shipping");
            Console.WriteLine("--------");
            Console.WriteLine();
            Console.WriteLine(order.ShipTo.Street);
            Console.WriteLine(order.ShipTo.City);
            Console.WriteLine(order.ShipTo.State);
            Console.WriteLine();

            Console.WriteLine("Billing");
            Console.WriteLine("-------");
            Console.WriteLine();
            if (order.BillTo == order.ShipTo)
            {
                Console.WriteLine("*same as shipping address*");
            }
            else
            {
                Console.WriteLine(order.ShipTo.Street);
                Console.WriteLine(order.ShipTo.City);
                Console.WriteLine(order.ShipTo.State);
            }
            Console.WriteLine();

            Console.WriteLine("Delivery instructions");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Console.WriteLine(order.SpecialDelivery);
            Console.ReadLine();
        }

        public class Order
        {
            public string Receipt { get; set; }
            public DateTime Date { get; set; }
            public Customer Customer { get; set; }
            public List<OrderItem> Items { get; set; }

            [YamlMember(typeof(Address), Alias = "bill_to")]
            //[YamlAlias("bill-to")]
            public Address BillTo { get; set; }

            [YamlMember(typeof(Address), Alias = "ship_to")]
            //[YamlAlias("ship-to")]
            public Address ShipTo { get; set; }

            public string SpecialDelivery { get; set; }
        }

        public class Customer
        {
            public string Given { get; set; }
            public string Family { get; set; }
        }

        public class OrderItem
        {
            [YamlMember(typeof(OrderItem), Alias = "part_no")]
            //[YamlAlias("part_no")]
            public string PartNo { get; set; }
            public string Descrip { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }
    }
}        
