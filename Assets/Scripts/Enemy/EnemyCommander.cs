using UnityEngine;

[RequireComponent(typeof(EnemyPatrolman))]
[RequireComponent(typeof(EnemyPlayerTracker))]
public class EnemyCommander : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _detectionDistance;

    private EnemyPatrolman _patrolman;
    private EnemyPlayerTracker _tracker;

    private Coroutine _currentRoutine;

    private void Awake() =>
        Initialize();

    private void Start() =>
        _currentRoutine = StartCoroutine(_patrolman.Patrolling());

    private void FixedUpdate()
    {
        RaycastHit2D hit = TryFindPlayer();

        if (hit)
        {
            CatchingPlayer(hit);
            return;
        }

        BackToPatrolling();
    }

    private RaycastHit2D TryFindPlayer() =>
        Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _detectionDistance, _playerMask);

    private void CatchingPlayer(RaycastHit2D hit)
    {
        StopCoroutine(_currentRoutine);
        _currentRoutine = StartCoroutine(_tracker.CatchUpWithPlayer(hit.point));
    }

    private void BackToPatrolling()
    {
        StopCoroutine(_currentRoutine);
        _tracker.IsCatchingStop();
        _currentRoutine = StartCoroutine(_patrolman.Patrolling());
    }

    private void Initialize()
    {
        _patrolman = GetComponent<EnemyPatrolman>();
        _tracker = GetComponent<EnemyPlayerTracker>();
    }
}