using System.Collections;
using UnityEngine;

public class EnemyController : CharacterController
{
    [SerializeField] private float _speed;

    public IEnumerator MoveToPoint(Vector2 point)
    {
        Animator.SetMove(point.x);

        while (Vector2.Distance(point, Rigidbody2D.position) > 1f)
        {
            Move(point);
            yield return null;
        }
    }

    public void Attacking() =>
        Animator.SetAttack();

    private void Move(Vector2 point)
    {
        Moving((point - Rigidbody2D.position).normalized.x * _speed, Rigidbody2D.velocity.y);
        Animator.SetMove(Rigidbody2D.velocity.x);
    }
}