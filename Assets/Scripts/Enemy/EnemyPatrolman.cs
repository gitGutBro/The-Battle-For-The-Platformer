using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyPatrolman : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private EnemyController _enemyMover;

    private int _currentPoint;

    private void Awake() =>
        Initialize();

    public IEnumerator Patrolling()
    {
        while (true)
        {
            yield return _enemyMover.MoveToPoint(_points[_currentPoint].transform.position);

            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;
        }
    }

    private void Initialize()
    {
        _enemyMover = GetComponent<EnemyController>();

        _points = new Transform[_path.childCount];
        GetPathChildren();
    }

    private void GetPathChildren()
    {
        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }
}