using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// แปะบน GameObject ของลูกค้า/โต๊ะ (ต้องมี Collider2D และมีคลาสที่ implement IOrderReceiver อยู่ในตัวเดียวกัน)
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class ServeTarget : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ServingSystem servingSystem;
    private IOrderReceiver receiver;

    private void Awake() => receiver = GetComponent<IOrderReceiver>();

    public void OnPointerClick(PointerEventData eventData) => servingSystem.TryServe(receiver);
}
