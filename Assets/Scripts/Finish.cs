using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.GetInt(GameManager.instance.GetSceneName() + "_star") == 1)
                PlayerPrefs.SetInt(GameManager.instance.GetSceneName() + "_star", 2);

            AudioManager.instance.Play("Win");

            Destroy(collision.gameObject);
            GameManager.instance.LoadNextLevel();
        }
    }
}