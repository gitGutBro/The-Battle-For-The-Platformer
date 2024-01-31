using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private Transform _hitArea;
    [SerializeField] private LayerMask _hitTarget;
    [SerializeField] private float _attackRange;

    public void Attack()
    {
        Collider2D[] hitTargets = TryFindTargets();

        foreach (Collider2D target in hitTargets)
            target.GetComponent<CharacterController>().Health.TakeDamage(target.GetComponent<CharacterAnimator>());
    }

    private Collider2D[] TryFindTargets() =>
        Physics2D.OverlapCircleAll(_hitArea.position, _attackRange, _hitTarget);

    private void OnDrawGizmosSelected()
    {
        if (_hitArea == null)
            return;

        Gizmos.DrawWireSphere(_hitArea.position, _attackRange);
    }
}