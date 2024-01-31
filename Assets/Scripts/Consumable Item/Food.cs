using UnityEngine;

public class Food : ConsumableItem
{
    public override void LeaveToPlayer(PlayerController player) =>
        player.Health.Heal();
}