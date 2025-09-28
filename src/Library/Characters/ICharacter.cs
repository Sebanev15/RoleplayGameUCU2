using Library.Items;

namespace Library.Characters;

public interface ICharacter
{
    public int Health { get; set; }
    public string Name { get; set; }
    public List<IItem> Items { get; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public void ReceiveAttack(int attackValue);
    public void Heal();
    public void AddItem(IItem itemAdded);
    public void RemoveItem(IItem itemAdded);
}