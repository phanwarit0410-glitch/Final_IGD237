using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>จุดวางวัตถุดิบ (ตู้เย็น/ถาด) แตะแล้วหยิบ 1 ชิ้นเข้ามือ</summary>
public class IngredientStation : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private IngredientData ingredient;
    [SerializeField] private PlayerHand hand;
    [Tooltip("-1 = ไม่จำกัดสต็อก")]
    [SerializeField] private int stock = -1;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (stock == 0) return;
        if (hand.PickIngredient(ingredient) && stock > 0) stock--;
    }
}
