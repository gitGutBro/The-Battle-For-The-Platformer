using UnityEngine;

public class PlayerController : CharacterController
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private CircleCollider2D _circleCollider2D;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool IsGrounded => WasGrounded();

    private void Update()
    {
        Move();
        TryJump();
        TryAttack();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis(Horizontal);

        Moving(moveHorizontal * _speed, Rigidbody2D.velocity.y);
        Animator.SetMove(Rigidbody2D.velocity.normalized.x);
    }

    private void TryJump()
    {
        Animator.SetJumping(IsGrounded);

        if (IsGrounded && Input.GetKeyDown(KeyCode.W))
            Jump();
        
        Animator.SetJumping(IsGrounded);
    }

    private void TryAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetAttack();
            Damager.Attack();
        }
    }

    private void Jump() =>
        Rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);

    private bool WasGrounded() => 
        Physics2D.OverlapCircleAll(_circleCollider2D.transform.position, _circleCollider2D.radius, _layerMask).Length > 0;
}