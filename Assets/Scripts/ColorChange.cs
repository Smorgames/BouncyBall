using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour
{


    [SerializeField] private ObjectType _objectType;
    [SerializeField] private Color _objectColor;
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private TouchEvent _playerTouchEvent;

    private void Awake()
    {
        _playerTouchEvent = GameObject.FindWithTag("Player").GetComponent<TouchEvent>();        
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        ChangeColor(_objectColor);

        StartCoroutine(SetPlatformColliderCoroutine());
    }

    private void OnEnable()
    {
        if (_objectType == ObjectType.Platform || _objectType == ObjectType.Finish) _playerTouchEvent.OnTouchColorChanger += _playerTouchEvent_OnTouchColorChanger;
    }

    private void _playerTouchEvent_OnTouchColorChanger()
    {
        StartCoroutine(SetPlatformColliderCoroutine());
    }

    public void ChangeColor (Color color)
    {
        SetSkin(color, (int)color);
    }

    public Color GetObjectColor()
    {
        return _objectColor;
    }

    private void SetSkin(Color color, int index)
    {
        _objectColor = color;
        _spriteRenderer.sprite = _sprites[index];
    }

    private IEnumerator SetPlatformColliderCoroutine()
    {
        if (_objectType == ObjectType.Platform) // Set platform collider depending on the player's color
        {
            yield return new WaitForSeconds(Time.deltaTime);
            ColorChange playerColorChange = GameObject.FindWithTag("Player").GetComponent<ColorChange>();

            if (_objectColor == playerColorChange.GetObjectColor())
                _collider.enabled = false;
            else
                _collider.enabled = true;
        }

        if (_objectType == ObjectType.Finish) // Set finish collider depending on the player's color
        {
            yield return new WaitForSeconds(Time.deltaTime);
            ColorChange playerColorChange = GameObject.FindWithTag("Player").GetComponent<ColorChange>();

            if (_objectColor == playerColorChange.GetObjectColor())
                _collider.enabled = true;
            else
                _collider.enabled = false;
        }
    }

    private void OnDestroy()
    {
        if (_objectType == ObjectType.Platform || _objectType == ObjectType.Finish) _playerTouchEvent.OnTouchColorChanger -= _playerTouchEvent_OnTouchColorChanger;
    }
}

public enum Color { Green, Blue, Purple, Red }
public enum ObjectType { Player, Platform, ColorChanger, Finish }