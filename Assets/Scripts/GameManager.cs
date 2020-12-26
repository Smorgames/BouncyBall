using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        _sceneName = SceneManager.GetActiveScene().name;
    }
    #endregion

    [SerializeField] private bool _needLoadNextLevel = true;
    [SerializeField] private Fader _fader;

    private string _nextLoadSceneName;
    private string _sceneName;
    public void LoadNextLevel()
    {
        if (_needLoadNextLevel)
        {
            SetNextSceneName();
            _fader.TriggerLoadSceneAnimation(_nextLoadSceneName);
        }
        else
        {
            _nextLoadSceneName = "Menu";
            _fader.TriggerLoadSceneAnimation(_nextLoadSceneName);
        }
    }

    public void SetNextSceneName()
    {
        string level = SceneManager.GetActiveScene().name; // level name
        string currentLevelNumberString = level[6].ToString() + level[7].ToString(); // last two numbers
        int nextLevelNumber = Convert.ToInt32(currentLevelNumberString); // convert last two numbers to int
        nextLevelNumber++;

        if (nextLevelNumber < 10)
            _nextLoadSceneName = "Level 0" + nextLevelNumber.ToString();
        else
            _nextLoadSceneName = "Level " + nextLevelNumber.ToString();
    }

    public string GetSceneName()
    {
        return _sceneName;
    }

    public int GetSceneNumber()
    {
        string level = SceneManager.GetActiveScene().name; // level name
        string currentLevelNumberString = level[6].ToString() + level[7].ToString(); // last two numbers
        int nextLevelNumber = Convert.ToInt32(currentLevelNumberString); // convert last two numbers to int

        return nextLevelNumber;
    }
}