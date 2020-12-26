using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDestroyer : MonoBehaviour
{
    private Animator _mainCamerAnimator;

    private string[] _deathSounds = new string[] { "Death1", "Death2", "Death3", "Death4", "Death5" };

    private void Start()
    {
        _mainCamerAnimator = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(GameOver(1, collision.gameObject));
        }
    }

    private IEnumerator GameOver(float delayBeforeDie, GameObject objectNeedDestroy)
    {
        _mainCamerAnimator.SetTrigger("Shake");
        objectNeedDestroy.GetComponent<Player>().PlayDeathEffect();
        AudioManager.instance.Play(_deathSounds[Random.Range(0, _deathSounds.Length)]);

        if (PlayerPrefs.GetInt(GameManager.instance.GetSceneName() + "_star") == 1)
            PlayerPrefs.SetInt(GameManager.instance.GetSceneName() + "_star", 0);

        Destroy(objectNeedDestroy);
        yield return new WaitForSeconds(delayBeforeDie);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}