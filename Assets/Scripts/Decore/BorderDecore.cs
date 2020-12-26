using UnityEngine;

public class BorderDecore : MonoBehaviour
{
    private Animator _animator;

    private string[] _triggerNames = { "GreenBorder", "BlueBorder", "PurpleBorder", "RedBorder" };

    private float _counter = 0.0f;
    private float _timeToNextSpawn = 5.0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= _timeToNextSpawn)
        {
            _animator.SetTrigger(_triggerNames[Random.Range(0, _triggerNames.Length)]);
            _timeToNextSpawn = Random.Range(6f, 10f);
            _counter = 0.0f;
        }
    }
}