using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GamManager : MonoBehaviour
{
    public static GamManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }
    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void OnLevelCompleted(int _level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,"Level:" + _level);
        Debug.Log("Level" + _level);
    }
}
