using UnityEngine;

/// <summary>สิ่งที่ผู้เล่นถืออยู่ ณ ตอนนี้: วัตถุดิบ 1 ชิ้น หรือ ชามที่ทำเสร็จ</summary>
public class PlayerHand : MonoBehaviour
{
    [SerializeField] private SpriteRenderer heldIcon; // ไอคอนลอยตามมือ/เมาส์ (ไม่ใส่ก็ได้)

    public IngredientData HeldIngredient { get; private set; }
    public Bowl HeldBowl { get; private set; }
    public bool IsEmpty => HeldIngredient == null && HeldBowl == null;

    public bool PickIngredient(IngredientData ingredient)
    {
        if (!IsEmpty) return false;           // มือไม่ว่าง
        HeldIngredient = ingredient;
        ShowIcon(ingredient.icon);
        GameEvents.IngredientPicked(ingredient);
        return true;
    }

    public bool PickBowl(Bowl bowl)
    {
        if (!IsEmpty) return false;
        HeldBowl = bowl;
        ShowIcon(bowl.CompletedRecipe != null ? bowl.CompletedRecipe.icon : null);
        return true;
    }

    public void ClearHeld()
    {
        HeldIngredient = null;
        HeldBowl = null;
        ShowIcon(null);
    }

    private void ShowIcon(Sprite s)
    {
        if (heldIcon == null) return;
        heldIcon.sprite = s;
        heldIcon.enabled = s != null;
    }

    private void Update()
    {
        // ให้ไอคอนลอยตามเมาส์/นิ้ว
        if (heldIcon != null && heldIcon.enabled && Camera.main != null)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0;
            heldIcon.transform.position = p;
        }
    }
}
