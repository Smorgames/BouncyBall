using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPositions;
    [SerializeField] private float _speed;

    private void Update()
    {
        Patroling();
    }

    private int i = 0;
    private void Patroling()
    {
        if (transform.position == _patrolPositions[i].position)
        {
            i++;

            if (i == _patrolPositions.Length)
                i = 0;
        }

        if (transform.position != _patrolPositions[i].position)
            transform.position = Vector3.MoveTowards(transform.position, _patrolPositions[i].position, _speed * Time.deltaTime);
    }
}