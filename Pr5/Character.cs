namespace Pr5
{
  public abstract class Character : IDamageable
  {
    private int _hp;
    private string _name;

    protected Character(string name)
    {
      _name = name;
    }

    public int Hp
    {
      get => _hp;

      set
      {
        _hp = value;
        
        Console.WriteLine($"* Здоров'є гравця {_name}, становить {_hp}HP *");
      }
    }

    public string Name
    {
      get => _name;
      
      protected set => _name = value;
    }

    public void TakeDamage(int damage)
    {
      Hp -= damage;
      
      Console.WriteLine($"- Гравець {Name} отримав {damage} урона.");
    }

    public abstract void Attack(IDamageable target);
  }
}
