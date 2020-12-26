using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    [SerializeField] private string _objectTag;

    public delegate void ObjectTouch();
    public event ObjectTouch OnTouchColorChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ColorChanger>() != null)
        {
            OnTouchColorChanger?.Invoke();
        }
    }
}
