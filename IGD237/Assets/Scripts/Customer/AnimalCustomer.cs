public class AnimalCustomer : Customer
{
    public string AnimalType { get; private set; }

    public AnimalCustomer(
        string id,
        string name,
        string animalType
    ) : base(id, name)
    {
        AnimalType = animalType;
    }
}
