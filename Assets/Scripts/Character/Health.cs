using UnityEngine;

public class Health : MonoBehaviour
{
    private const int MaxHealth = 3;

    private int _health;

    private bool IsAlive() => _health > 0;

    private void Start() =>
        _health = MaxHealth;

    public void TakeDamage(CharacterAnimator animator)
    {
        Reduce();

        if(IsAlive() == false)
            animator.SetDeath();
    }

    public void Heal() =>
        _health += (_health == MaxHealth) ? 0 : 1;

    private void Die() =>
        Destroy(gameObject);

    private void Reduce() =>
        _health--;
}