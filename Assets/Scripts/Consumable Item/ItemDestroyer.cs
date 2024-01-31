using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    public void TryDestroy(Collider2D collider, ConsumableItem item)
    {
        if (collider.gameObject.TryGetComponent(out PlayerController player))
        {
            item.LeaveToPlayer(player);
            item.gameObject.SetActive(false);
            Destroy(item.gameObject);
        }
    }
}