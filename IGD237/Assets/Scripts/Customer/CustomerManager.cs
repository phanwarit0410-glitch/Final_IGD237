using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour, ICustomerProvider
{
    [SerializeField]
    private List<CustomerData> customerDatabase;

    public CustomerData GetRandomCustomer()
    {
        if (customerDatabase.Count == 0)
            return null;

        int index = Random.Range(0, customerDatabase.Count);

        return customerDatabase[index];
    }
}