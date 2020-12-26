using UnityEngine;
using UnityEngine.Advertisements;
using System;
using System.Collections;

public class AD_MANAGER : MonoBehaviour
{
    public static AD_MANAGER instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private string _rewardedVideo = "rewardedVideo";
    private string _video = "video";

    private bool _firstShow = true;

    IEnumerator Start()
    {
        //Advertisement.AddListener(this);

        Advertisement.Initialize("3935489", true);

        while (!Advertisement.IsReady(_video))
        {
            yield return null;
        }

        if (_firstShow)
            Advertisement.Show(_video);

        _firstShow = false;
    }
}