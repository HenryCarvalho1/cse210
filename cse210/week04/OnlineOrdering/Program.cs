using System;

class Program
{
    static void Main(string[] args)
    {   
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product p1 = new Product("Wireless Mouse", 101, 25.50, 1);
        Product p2 = new Product("Mechanical Keyboard", 102, 79.99, 1);
        Product p3 = new Product("AA Batteries (4-pack)", 103, 5.99, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);
        order1.AddProduct(p3);
        
        Address address2 = new Address("Av. Paulista, 1000", "São Paulo", "SP", "Brazil");
        Customer customer2 = new Customer("Henry Carvalho", address2);

        Product p4 = new Product("UltraWide Monitor 34\"", 201, 349.99, 1);
        Product p5 = new Product("HDMI Cable 2m", 202, 12.50, 2);

        Order order2 = new Order(customer2);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        Console.WriteLine("==================================================");
        Console.WriteLine("             ONLINE ORDERING SYSTEM              ");
        Console.WriteLine("==================================================\n");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n--------------------------------------------------\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("\n==================================================");
    }
}
