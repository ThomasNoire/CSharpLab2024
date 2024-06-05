namespace Pr4
{
  public class FireWizard : Character
  {
    private ISpell _spell;

    public FireWizard(int hp, ISpell spell, string name) : base(name)
    {
      Hp = hp;
      
      _spell = spell;
    }

    public override void Attack(IDamageable target)
    {
      _spell.CauseDamage(target);
      
      Console.WriteLine($"* {Name} використовує закляття на {((Character)target).Name} *");
    }
  }
}
