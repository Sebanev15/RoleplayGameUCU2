using Library.Characters;
using Ucu.Poo.RoleplayGame;

SpellsBook book = new SpellsBook();
book.AddSpell(new Spell(40,40));
Wizard gandalf = new Wizard("Gandalf", 10, 100);
gandalf.AddItem(new Staff(20,20,true));
gandalf.AddItem(book);

Dwarf gimli = new Dwarf("Gimli",30,100);
gimli.AddItem(new Axe(30,10,false));
gimli.AddItem(new Helmet(false, 50, 30));
gimli.AddItem(new Shield(0,60,true));

Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.GetTotalAttack()}");

gimli.ReceiveAttack(gandalf.GetTotalAttack());

Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

gimli.Heal();

Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

