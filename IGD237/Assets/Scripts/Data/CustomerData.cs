using UnityEngine;

[CreateAssetMenu(menuName = "Game/Customer Data")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public string animalType;
    public Sprite customerSprite;
}