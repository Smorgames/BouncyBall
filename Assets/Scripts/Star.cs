using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private GameObject _starPickEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            PlayerPrefs.SetInt(GameManager.instance.GetSceneName() + "_star", 1);

            AudioManager.instance.Play("PickStar");
            //Debug.Log(GameManager.instance.GetSceneName() + "_star"); // ----------------------------------------------------------------------------------DEBUG
            //Debug.Log(PlayerPrefs.GetInt(GameManager.instance.GetSceneName() + "_star")); // --------------------------------------------------------------DEBUG

            Instantiate(_starPickEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}