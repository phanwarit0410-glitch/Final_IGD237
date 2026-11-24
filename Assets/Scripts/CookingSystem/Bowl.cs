using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BowlState { Empty, InProgress, Complete }

/// <summary>
/// ชามใส่วัตถุดิบ ต้องมี Collider2D + ให้ Camera มี Physics2DRaycaster (และมี EventSystem ใน Scene)
/// </summary>
public class Bowl : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PlayerHand hand;
    [SerializeField] private RecipeDatabase recipeDatabase;

    private readonly Dictionary<IngredientData, int> contents = new Dictionary<IngredientData, int>();

    public IReadOnlyDictionary<IngredientData, int> Contents => contents;
    public BowlState State { get; private set; } = BowlState.Empty;
    /// <summary>สูตรที่ชามนี้ตรงอยู่ (null ถ้ายังไม่ครบ)</summary>
    public RecipeData CompletedRecipe { get; private set; }

    public void Add(IngredientData ingredient)
    {
        if (State == BowlState.Complete) return; // ชามเสร็จแล้ว ห้ามเติม
        contents[ingredient] = contents.TryGetValue(ingredient, out int n) ? n + 1 : 1;
        GameEvents.IngredientAdded(ingredient);
        Refresh();
    }

    public void Clear()
    {
        contents.Clear();
        CompletedRecipe = null;
        State = BowlState.Empty;
        GameEvents.BowlCleared();
    }

    private void Refresh()
    {
        CompletedRecipe = RecipeValidator.FindMatch(contents, recipeDatabase.recipes);
        if (CompletedRecipe != null)
        {
            State = BowlState.Complete;
            GameEvents.BowlCompleted(this);
        }
        else State = contents.Count == 0 ? BowlState.Empty : BowlState.InProgress;
    }

    /// <summary>ตรวจเทียบกับสูตรที่ระบุ (ใช้แสดง UI ว่าขาดอะไร)</summary>
    public ValidationResult CheckAgainst(RecipeData recipe) => RecipeValidator.Validate(contents, recipe);

    // แตะชาม: ถ้าถือวัตถุดิบอยู่ -> ใส่ลงชาม / ถ้ามือว่างและชามเสร็จ -> ยกชามไปเสิร์ฟ
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hand.HeldIngredient != null)
        {
            Add(hand.HeldIngredient);
            hand.ClearHeld();
        }
        else if (State == BowlState.Complete && hand.HeldBowl == null)
        {
            hand.PickBowl(this);
        }
    }
}
