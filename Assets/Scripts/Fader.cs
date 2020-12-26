using UnityEngine.SceneManagement;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private string _loadSceneName;

    private Animator _faderAnimator;

    private void Start()
    {
        _faderAnimator = GetComponent<Animator>();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_loadSceneName);
    }

    //public void SetLoadSceneName(string value)
    //{
    //    _loadSceneName = value;
    //}

    public void TriggerLoadSceneAnimation(string sceneName)
    {
        AudioManager.instance.Play("Click");
        AudioManager.instance.Play("Transition");

        _loadSceneName = sceneName;
        _faderAnimator.SetTrigger("FadeIn");
    }

    public void Retry()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}