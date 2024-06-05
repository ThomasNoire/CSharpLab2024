namespace Pr5
{
  public interface IDamageable
  {
    int Hp { get; set; }

    void TakeDamage(int damage);
  }
}
