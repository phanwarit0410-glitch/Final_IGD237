using System.Collections.Generic;
using UnityEngine;

/// <summary>รวมสูตรทั้งหมดไว้ที่เดียว สร้างผ่าน Assets > Create > Cooking > Recipe Database</summary>
[CreateAssetMenu(menuName = "Cooking/Recipe Database")]
public class RecipeDatabase : ScriptableObject
{
    public List<RecipeData> recipes = new List<RecipeData>();
}
