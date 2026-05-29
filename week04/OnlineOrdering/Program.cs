using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First order (customer in the USA -> $5 shipping)
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "A100", 25.50, 2));
        order1.AddProduct(new Product("Keyboard", "A101", 45.00, 1));
        order1.AddProduct(new Product("USB Cable", "A102", 8.75, 3));

        // Second order (customer outside the USA -> $35 shipping)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("David Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "B200", 60.00, 1));
        order2.AddProduct(new Product("Phone Case", "B201", 15.25, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }
    }
}