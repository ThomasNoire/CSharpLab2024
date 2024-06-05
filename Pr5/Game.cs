namespace Pr5
{
  public class Game
  {
    public delegate void ElementalEffectivity(ISpell spell, IDamageable target);

    public void FireVSIce(ISpell spell, IDamageable target)
    {
      if (spell is FireBall or FireBlast && target is IceWizard)
      {
        int doubleDamage = spell.Damage * 2;
        
        Console.WriteLine($"* Вогняне заклинання вражає мага льоду! Завдано {doubleDamage} урону. *");
        
        target.TakeDamage(doubleDamage);
      }
      else
      {
        spell.CauseDamage(target);
      }
    }

    public void Start()
    {
      Console.WriteLine("Вітаю в грі! Оберіть персонажа для продовження:");
      Console.WriteLine("1. Маг вогню");
      Console.WriteLine("2. Маг льоду");
      Console.WriteLine("");

      int userChoice = GetValidChoice(1, 2);

      Character player1;

      if (userChoice == 1)
      {
        player1 = CreateWizard("Маг вогню", new FireWizard(100, new FireBall(10), "Могус", FireVSIce), new FireBlast(20));
      }
      else
      {
        player1 = CreateWizard("Маг льоду", new IceWizard(100, new IceShard(15), "Могус"), new IceBeam(25));
      }

      Character player2 = new FireWizard(100, new FireBall(10), "Угус", FireVSIce);

      Console.WriteLine("\nГра почалась!\n");

      while (player1.Hp > 0 && player2.Hp > 0)
      {
        Console.WriteLine("\nНатисніть на клавішу для продовження...\n");
        Console.ReadKey(true);

        player2.Attack(player1);

        if (player1.Hp <= 0 || player2.Hp <= 0)
          break;

        Console.WriteLine("\nНатисніть на клавішу для продовження...\n");
        Console.ReadKey(true);

        player1.Attack(player2);
      }

      Console.WriteLine("\nГра завершена!\n");
    }

    private int GetValidChoice(int min, int max)
    {
      int choice;

      do
      {
        Console.Write("Введіть ваш вибір (1 або 2): ");
      } while (!int.TryParse(Console.ReadLine(), out choice) || (choice < min || choice > max));
      
      return choice;
    }

    private Character CreateWizard(string wizardType, Character wizard, Spell spell)
    {
      Console.WriteLine($"\n- Ви обрали {wizardType}. Яке заклинання ви хочете мати?");
      Console.WriteLine("1. Вогнянний вибух");
      Console.WriteLine("2. Вогнянний шар");
      Console.WriteLine("");

      int choice = GetValidChoice(1, 2);

      if (choice == 1)
      {
        wizard = new FireWizard(100, new FireBall(10), "Могус", FireVSIce);
      }
      else
      {
        wizard = new FireWizard(100, new FireBlast(20), "Могус", FireVSIce);
      }

      return wizard;
    }
  }
}
