using UnityEngine;

public class BlockedPlatform : MonoBehaviour
{
    [SerializeField] private Transform _openPoint;
    [SerializeField] private float _speed;

    private bool _startOpening = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_startOpening)
            OpenPlatform();
    }

    public void StartOpening()
    {
        _startOpening = true;
    }

    public void StartOpeningAnimation()
    {
        _animator.SetTrigger("Open");
    }

    private void OpenPlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _openPoint.position, _speed * Time.deltaTime);

        if (Mathf.Abs((transform.position - _openPoint.position).magnitude) < 0.1f)
            Destroy(this);
    }
}