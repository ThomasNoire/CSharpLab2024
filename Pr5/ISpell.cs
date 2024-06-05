namespace Pr5
{
  public interface ISpell
  {
    int Damage { get; }

    void CauseDamage(IDamageable target);
  }
}
