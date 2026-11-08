[System.Serializable]
public class OrderItem
{
    public string foodName;
    public int quantity;

    public OrderItem(string name, int amount)
    {
        foodName = name;
        quantity = amount;
    }
}