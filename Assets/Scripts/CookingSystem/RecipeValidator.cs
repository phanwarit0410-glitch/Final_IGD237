using System.Collections.Generic;

public struct ValidationResult
{
    public bool isComplete;                                   // ครบพอดี
    public Dictionary<IngredientData, int> missing;           // ขาดอะไรเท่าไหร่
    public Dictionary<IngredientData, int> extra;             // เกิน/ผิดชนิด
}

/// <summary>ตรวจว่าของในชามตรงกับสูตรไหม (ไม่สนลำดับการใส่)</summary>
public static class RecipeValidator
{
    public static ValidationResult Validate(IReadOnlyDictionary<IngredientData, int> contents, RecipeData recipe)
    {
        var result = new ValidationResult
        {
            missing = new Dictionary<IngredientData, int>(),
            extra = new Dictionary<IngredientData, int>()
        };

        var required = new Dictionary<IngredientData, int>();
        foreach (var r in recipe.ingredients) required[r.ingredient] = r.amount;

        foreach (var kv in required)
        {
            contents.TryGetValue(kv.Key, out int have);
            if (have < kv.Value) result.missing[kv.Key] = kv.Value - have;
        }
        foreach (var kv in contents)
        {
            required.TryGetValue(kv.Key, out int need);
            if (kv.Value > need) result.extra[kv.Key] = kv.Value - need;
        }

        result.isComplete = result.missing.Count == 0 && result.extra.Count == 0;
        return result;
    }

    /// <summary>หาสูตรที่ตรงกับของในชามพอดี (คืน null ถ้าไม่มี)</summary>
    public static RecipeData FindMatch(IReadOnlyDictionary<IngredientData, int> contents, IEnumerable<RecipeData> recipes)
    {
        foreach (var r in recipes)
            if (Validate(contents, r).isComplete) return r;
        return null;
    }
}
