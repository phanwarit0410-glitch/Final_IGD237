using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RecipeIngredient
{
    public IngredientData ingredient;
    [Min(1)] public int amount;
}

/// <summary>สร้างผ่านเมนู Assets > Create > Cooking > Recipe</summary>
[CreateAssetMenu(menuName = "Cooking/Recipe")]
public class RecipeData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
    public int price = 10;
    public float cookTime = 0f;       // 0 = ไม่ต้องรอ
}
