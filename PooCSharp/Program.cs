using System;
using System.Globalization;
using PooCSharp.Entities;
using PooCSharp.Entities.enums;


namespace PooCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data:");
            Console.Write("Name:");
            string clientName = Console.ReadLine();

            Console.Write("Email:");
            string clientEmail = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY)");
            DateTime clientBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order Data:");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, clientBirth);
            Order order = new Order(client, DateTime.Now, orderStatus);

            Console.Write("How many items to this order:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name:");
                string productName = Console.ReadLine();

                Console.Write("Product price");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, productPrice);

                Console.Write("Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, productPrice, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("Order Summary:");
            Console.WriteLine(order);
        }
    }
}