using UnityEngine;

public class AddStartForce : MonoBehaviour
{
    [SerializeField] private float _forceAmount;

    private Rigidbody2D _rigidBody;

    private bool _isFirstClick = true;
    private Vector3 _camerOffset = new Vector3(0f, 0f, 10f);

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && _isFirstClick)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 fingerPosition = Camera.main.ScreenToWorldPoint(touch.position) + _camerOffset;
                Vector3 viewportFingerPosition = Camera.main.ScreenToViewportPoint(touch.position);

                if (!(viewportFingerPosition.x >= 0.0f && viewportFingerPosition.x <= 0.1f && viewportFingerPosition.y <= 1.0f && viewportFingerPosition.y >= 0.9f))
                {
                    _isFirstClick = false;
                    Vector3 forceDirection = (fingerPosition - transform.position).normalized;
                    _rigidBody.AddForce(forceDirection * _forceAmount, ForceMode2D.Impulse);
                }
            }
        }
    }
}