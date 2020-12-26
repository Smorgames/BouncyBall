using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Color _objectColor;

    private void Start()
    {
        _objectColor = GetComponent<ColorChange>().GetObjectColor();
    }
    private void OnTriggerEnter2D(Collider2D collision) // If it's color changer => change player's color to this object color
    {
        if (collision.tag == "Player")
        {
            ColorChange playerColorChange = collision.GetComponent<ColorChange>();

            AudioManager.instance.Play("TouchColor");

            playerColorChange.ChangeColor(_objectColor);
            // spawn effect;
            Destroy(gameObject);
        }
    }
}
