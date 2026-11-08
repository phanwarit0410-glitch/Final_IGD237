public class Customer
{
    public string CustomerID { get; private set; }
    public string CustomerName { get; private set; }

    public Customer(string id, string name)
    {
        CustomerID = id;
        CustomerName = name;
    }
}