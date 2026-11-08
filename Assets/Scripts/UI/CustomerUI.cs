using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private Image customerImage;
    [SerializeField] private TMP_Text customerName;

    public void DisplayCustomer(CustomerData data)
    {
        customerImage.sprite = data.customerSprite;
        customerName.text = data.customerName;
    }
}