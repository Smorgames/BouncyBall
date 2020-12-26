using UnityEngine;

public class BouncyHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            AudioManager.instance.Play("BouncyHit");
    }
}