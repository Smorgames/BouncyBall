using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Fader _fader;

    public void FadeIn()
    {
        _fader.TriggerLoadSceneAnimation("Menu");
    }
}