using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>ปุ่ม/ถังขยะ สำหรับเทของในชามทิ้งหรือทิ้งของในมือ (ผูกกับ Collider2D หรือ UI ก็ได้)</summary>
public class ClearBowlButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Bowl bowl;
    [SerializeField] private PlayerHand hand;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hand.IsEmpty) hand.ClearHeld();
        else bowl.Clear();
    }
}
