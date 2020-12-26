using UnityEngine;

public class LevelSelectButtonController : MonoBehaviour
{
    public bool ResetStars; //------------------------------------------------------------------------DEBUG
    public bool OpenAll; //---------------------------------------------------------------------------DEBUG

    private LevelSelectButton[] _buttons;

    private void Start()
    {
        int buttonsAmount = transform.childCount;
        _buttons = new LevelSelectButton[buttonsAmount];

        for (int i = 0; i < buttonsAmount; i++)
        {
            _buttons[i] = transform.GetChild(i).GetComponent<LevelSelectButton>();
            if (i != 0)
                _buttons[i].SetLoadSceneName(SetButtonLoadSceneName(i));
            _buttons[i].SetNumberOfButton(i + 1);

            //----------------------------------------------------------------------------------------DEBUG
            if (ResetStars)
            {
                if (i != 0)
                    PlayerPrefs.SetInt(_buttons[i].GetLoadSceneName(), 0);
                PlayerPrefs.SetInt(_buttons[i].GetLoadSceneName() + "_star", 0);
            }
            //----------------------------------------------------------------------------------------DEBUG
        }

        //--------------------------------------------------------------------------------------------DEBUG
        if (OpenAll)
            for (int i = 0; i < buttonsAmount; i++)
                _buttons[i].SetInteractable(1);
        //--------------------------------------------------------------------------------------------DEBUG
    }

    private string SetButtonLoadSceneName(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex <= 8)
            return "Level 0" + (buttonIndex + 1).ToString();
        else
            return "Level " + (buttonIndex + 1).ToString();
    }
}