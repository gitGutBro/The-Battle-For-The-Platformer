using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyPlayerTracker : MonoBehaviour
{
    private EnemyController _controller;
    public bool IsCatchingPlayer { get; private set; }

    private void Awake() =>
        _controller = GetComponent<EnemyController>();

    public IEnumerator CatchUpWithPlayer(Vector2 playerPosition)
    {
        IsCatchingPlayer = true;

        while (true)
            yield return _controller.MoveToPoint(playerPosition);
    }

    public void IsCatchingStop() =>
        IsCatchingPlayer = false;
}