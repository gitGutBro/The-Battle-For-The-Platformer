using UnityEngine;

[RequireComponent(typeof(Damager))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(CharacterFliper))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class CharacterController : MonoBehaviour
{
    public Health Health { get; private set; }
    protected Damager Damager { get; private set; } 
    protected CharacterAnimator Animator { get; private set; }
    protected Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake() =>
        Initialize();

    protected void Moving(float x, float y) =>
        Rigidbody2D.velocity = new Vector2(x, y);

    protected virtual void OnInitialize() { }

    private void Initialize()
    {
        Damager = GetComponent<Damager>();
        Health = GetComponent<Health>();
        Animator = GetComponent<CharacterAnimator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        OnInitialize();
    }
}