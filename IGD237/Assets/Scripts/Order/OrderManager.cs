using UnityEngine;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    [SerializeField]
    private List<string> foodDatabase;

    public Order GenerateRandomOrder()
    {
        List<OrderItem> items = new List<OrderItem>();

        int itemCount = Random.Range(1, 4);

        for (int i = 0; i < itemCount; i++)
        {
            string food = foodDatabase[
                Random.Range(0, foodDatabase.Count)
            ];

            items.Add(new OrderItem(food, 1));
        }

        return new Order(
            System.Guid.NewGuid().ToString(),
            items
        );
    }
}