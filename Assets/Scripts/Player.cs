using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _deathEffect;

    public void PlayDeathEffect()
    {
        GameObject deathEffect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 3f);
    }
}
