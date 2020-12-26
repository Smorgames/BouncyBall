using UnityEngine;

public class RotationAroundDecore : MonoBehaviour
{
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.RotateAround(_rotationPoint.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
