namespace Pr5
{
  public class FireWizard : Character
  {
    private ISpell _spell;
    private Game.ElementalEffectivity _elementalHandler;

    public FireWizard(int hp, ISpell spell, string name, Game.ElementalEffectivity elementalHandler) : base(name)
    {
      Hp = hp;
      
      _spell = spell;
      _elementalHandler = elementalHandler;
    }

    public override void Attack(IDamageable target)
    {
      _spell.CauseDamage(target);
      
      Console.WriteLine($"* {Name} використовує закляття на {((Character)target).Name} *");

      _elementalHandler(_spell, target);
    }
  }
}
