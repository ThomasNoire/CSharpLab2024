namespace Pr5
{
  public abstract class Spell : ISpell
  {
    private int _damage;

    public int Damage
    {
      get => _damage;

      internal set => _damage = value;
    }

    public void CauseDamage(IDamageable target)
    {
      target.TakeDamage(_damage);
    }

  }
}
