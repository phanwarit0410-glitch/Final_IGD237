using UnityEngine;

/// <summary>ตรวจว่าชามที่ถือตรงกับออเดอร์ไหม แล้วแจ้งผล</summary>
public class ServingSystem : MonoBehaviour
{
    [SerializeField] private PlayerHand hand;
    [SerializeField] private int wrongOrderPenalty = 0;

    /// <summary>เรียกจากตัวลูกค้า/โต๊ะ ตอนผู้เล่นแตะ (ดู ServeTarget)</summary>
    public bool TryServe(IOrderReceiver customer)
    {
        if (hand.HeldBowl == null || customer == null || !customer.IsWaitingForFood) return false;

        Bowl bowl = hand.HeldBowl;
        RecipeData served = bowl.CompletedRecipe;
        bool correct = served != null && served == customer.OrderedRecipe;
        int money = correct ? served.price : -wrongOrderPenalty;

        customer.OnServed(correct, served, money);
        GameEvents.FoodServed(correct, served, money);

        bowl.Clear();
        hand.ClearHeld();
        return true;
    }
}
