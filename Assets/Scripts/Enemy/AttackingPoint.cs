using UnityEngine;

public class AttackingPoint : MonoBehaviour
{
    EnemyController _enemyController;

    private void Awake() =>
        _enemyController = GetComponentInParent<EnemyController>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
            _enemyController.Attacking();
    }
}