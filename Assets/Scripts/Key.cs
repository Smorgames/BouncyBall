using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private BlockedPlatform _blockedPlatform;
    [SerializeField] private GameObject _keyPickEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _blockedPlatform.StartOpeningAnimation();

            AudioManager.instance.Play("PickKey");

            GameObject effect = Instantiate(_keyPickEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            Destroy(gameObject);
        }
    }
}