
using UnityEngine;

public class OrderEventTester : MonoBehaviour
{
    public void TestCorrectOrder()
    {
        GameEvents.FoodServed(true, null, 50);
    }

    public void TestWrongOrder()
    {
        GameEvents.FoodServed(false, null, 0);
    }
}
