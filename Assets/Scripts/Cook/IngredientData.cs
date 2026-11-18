using UnityEngine;

public enum IngredientCategory { Meat, Vegetable, Fruit, Egg, Other }

/// <summary>สร้างผ่านเมนู Assets > Create > Cooking > Ingredient</summary>
[CreateAssetMenu(menuName = "Cooking/Ingredient")]
public class IngredientData : ScriptableObject
{
    public string id;                 // เช่น "carrot"
    public string displayName;        // เช่น "แครอท"
    public Sprite icon;
    public IngredientCategory category;
}
