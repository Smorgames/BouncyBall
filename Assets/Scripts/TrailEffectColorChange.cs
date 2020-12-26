using UnityEngine;
using System.Collections;

public class TrailEffectColorChange : MonoBehaviour
{
    [SerializeField] private Color _objectColor;
    [SerializeField] private Sprite[] _sprites;

    private ParticleSystem _particalSystem;

    private TouchEvent _playerTouchEvent;

    private void Awake()
    {
        _playerTouchEvent = GameObject.FindWithTag("Player").GetComponent<TouchEvent>();
    }

    private void Start()
    {
        _particalSystem = GetComponent<ParticleSystem>();

        ColorChange playerColorChange = GameObject.FindWithTag("Player").GetComponent<ColorChange>();
        ChangeColor(playerColorChange.GetObjectColor());
    }

    private void OnEnable()
    {
        _playerTouchEvent.OnTouchColorChanger += _playerTouchEvent_OnTouchColorChanger;
    }

    private void _playerTouchEvent_OnTouchColorChanger()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        ColorChange playerColorChange = GameObject.FindWithTag("Player").GetComponent<ColorChange>();
        ChangeColor(playerColorChange.GetObjectColor());
    }

    private void SetSkin(Color color, int index)
    {
        _objectColor = color;
        _particalSystem.textureSheetAnimation.SetSprite(0, _sprites[index]);
    }

    public void ChangeColor(Color color)
    {
        SetSkin(color, (int)color);
    }

    private void OnDisable()
    {
        _playerTouchEvent.OnTouchColorChanger -= _playerTouchEvent_OnTouchColorChanger;
    }
}