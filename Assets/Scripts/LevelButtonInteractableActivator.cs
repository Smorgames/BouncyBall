using UnityEngine;

public class LevelButtonInteractableActivator : MonoBehaviour
{
    private void Start()
    {
        string sceneName = GameManager.instance.GetSceneName();
        PlayerPrefs.SetInt(sceneName, 1); // set level button interactable = true
    }
}