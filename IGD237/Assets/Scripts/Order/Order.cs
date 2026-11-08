using System.Collections.Generic;

public class Order
{
    public string OrderID { get; private set; }
    public List<OrderItem> Items { get; private set; }

    public Order(string id, List<OrderItem> items)
    {
        OrderID = id;
        Items = items;
    }
}
