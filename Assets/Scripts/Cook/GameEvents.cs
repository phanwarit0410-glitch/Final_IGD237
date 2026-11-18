using System;

/// <summary>Event กลาง ใช้เชื่อมกับระบบของคนอื่น (UI, เศรษฐกิจ, ลูกค้า) โดยไม่ผูกกันตรงๆ</summary>
public static class GameEvents
{
    public static event Action<IngredientData> OnIngredientPicked;
    public static event Action<IngredientData> OnIngredientAdded;
    public static event Action OnBowlCleared;
    public static event Action<Bowl> OnBowlCompleted;
    /// <summary>success, recipe ที่เสิร์ฟ, เงินที่ได้</summary>
    public static event Action<bool, RecipeData, int> OnFoodServed;

    public static void IngredientPicked(IngredientData i) => OnIngredientPicked?.Invoke(i);
    public static void IngredientAdded(IngredientData i) => OnIngredientAdded?.Invoke(i);
    public static void BowlCleared() => OnBowlCleared?.Invoke();
    public static void BowlCompleted(Bowl b) => OnBowlCompleted?.Invoke(b);
    public static void FoodServed(bool ok, RecipeData r, int money) => OnFoodServed?.Invoke(ok, r, money);
}
