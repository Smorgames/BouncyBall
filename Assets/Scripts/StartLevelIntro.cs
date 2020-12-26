using UnityEngine;
using TMPro;

public class StartLevelIntro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelNumberText;

    private void Start()
    {
        _levelNumberText.text = "Level " + GameManager.instance.GetSceneNumber().ToString();
    }
}