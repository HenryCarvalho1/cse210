using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double subtotal = 0;
        foreach(Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        double shippingCost = 0;
        if (_customer.IsUSA())
        {
            shippingCost = 5.0;
        }
        else
        {
            shippingCost = 35.0;
        }

        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- PACKING LABEL ---\n";

        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetId()})\n";
        }

    return label;
}
        public string GetShippingLabel()
    {
        string label = "--- SHIPPING LABEL ---\n";
        
        label += $"Customer Name: {_customer.GetDisplayName()}\n";
        label += $"Address:\n{_customer.GetDisplayAddress()}\n";

        return label;
    }

}