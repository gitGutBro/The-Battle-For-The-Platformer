using UnityEngine;

[RequireComponent(typeof(ItemDestroyer))]
public abstract class ConsumableItem : MonoBehaviour
{
    protected ItemDestroyer Destroyer { get; private set; }

    private void Awake() =>
        Initialize();

    public virtual void LeaveToPlayer(PlayerController player) { }

    protected virtual void OnInitialize() { }

    private void OnTriggerEnter2D(Collider2D collider) =>
        Destroyer.TryDestroy(collider, this);

    private void Initialize()
    {
        Destroyer = GetComponent<ItemDestroyer>();
        OnInitialize();
    }
}