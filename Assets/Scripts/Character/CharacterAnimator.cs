using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterFliper))]
public class CharacterAnimator : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public CharacterFliper Fliper { get; private set; }

    private void Awake() =>
        Initialize();

    public void SetDeath() =>
        Animator.SetBool(CharacterAnimatorData.Params.Die, true);

    public void SetMove(float position)
    {
        Animator.SetFloat(CharacterAnimatorData.Params.HorizontalMove, Mathf.Abs(position));
        Fliper.TryFlip(position);
    }

    public void SetJumping(bool isGrounded) =>
        Animator.SetBool(CharacterAnimatorData.Params.Jumping, !isGrounded);

    public void SetAttack() =>
        Animator.SetTrigger(CharacterAnimatorData.Params.Hit);

    private void Initialize()
    {
        Animator = GetComponent<Animator>();
        Fliper = GetComponent<CharacterFliper>();
    }
}