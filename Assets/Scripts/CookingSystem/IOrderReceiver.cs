/// <summary>
/// Interface ที่ "คนทำระบบลูกค้า" ต้อง implement ให้ลูกค้า/โต๊ะ
/// ระบบ Serving จะคุยกับลูกค้าผ่านตัวนี้เท่านั้น
/// </summary>
public interface IOrderReceiver
{
    RecipeData OrderedRecipe { get; }          // เมนูที่ลูกค้าสั่ง
    bool IsWaitingForFood { get; }             // ลูกค้ายังรออยู่ไหม
    void OnServed(bool correct, RecipeData served, int payment); // แจ้งผลให้ลูกค้าตอบสนอง
}
