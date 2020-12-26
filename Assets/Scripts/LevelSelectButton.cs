using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private Fader _fader;
    [SerializeField] private TextMeshProUGUI _number;

    [SerializeField] private Image _starImage;
    [SerializeField] private Sprite[] _starSprites;

    [SerializeField] private string _loadSceneName;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        if (_loadSceneName == "Level 01")
            PlayerPrefs.SetInt(_loadSceneName, 1);
    }

    private void Start()
    {
        SetStarSprite();
    }

    public void SetLoadSceneName(string value)
    {
        _loadSceneName = value;

        InteractableCheck();
    }

    public void LoadScene()
    {
        _fader.TriggerLoadSceneAnimation(_loadSceneName);
    }

    public void SetInteractable(int value)
    {
        PlayerPrefs.SetInt(_loadSceneName, value); // if value = 0 => interactable = false; 
    }                                              // if value = 1 => interactable = true;

    private void InteractableCheck()
    {
        if (PlayerPrefs.GetInt(_loadSceneName) == 0)
            _button.interactable = false;
        else if (PlayerPrefs.GetInt(_loadSceneName) == 1)
            _button.interactable = true;
    }

    private void SetStarSprite()
    {
        if (PlayerPrefs.GetInt(_loadSceneName + "_star") == 0)
            _starImage.sprite = _starSprites[0];
        else if (PlayerPrefs.GetInt(_loadSceneName + "_star") == 2)
            _starImage.sprite = _starSprites[1];

        //Debug.Log(_loadSceneName + "_star"); // ------------------------------------------------------------------------------------------------------DEBUG
        //Debug.Log(PlayerPrefs.GetInt(_loadSceneName + "_star")); // ----------------------------------------------------------------------------------DEBUG
    }

    public void SetNumberOfButton(int index)
    {
        _number.text = index.ToString();
    }

    public string GetLoadSceneName()
    {
        return _loadSceneName;
    }
}