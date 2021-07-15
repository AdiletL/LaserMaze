using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextLvl : MonoBehaviour
{
    int lvl = 0;
    public void SendLevelEnd(int lvl)
    {
        Dictionary<string, object> tutParams = new Dictionary<string, object>();
        tutParams["Level Number"] = lvl;
        Debug.Log(lvl);
    }
    public void SendEventsBuffer() 
    {
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl", lvl) + 1);
        PlayerPrefs.Save();
        
        if (PlayerPrefs.GetInt("lvl") < 11)
        {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lvl", lvl));
        }
        else 
        {
            PlayerPrefs.SetInt("lvl", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(PlayerPrefs.GetInt("lvl", lvl));
        }GamManager.instance.OnLevelCompleted(PlayerPrefs.GetInt("lvl"));
        FacebookManager.Instance.LevelCompleted(PlayerPrefs.GetInt("lvl"));
        SendLevelEnd(PlayerPrefs.GetInt("lvl"));
        AppMetrica.Instance.SendEventsBuffer();
    }
   public void Restart() { 
        SceneManager.LoadScene(PlayerPrefs.GetInt("lvl")); 
        GamManager.instance.OnLevelCompleted(PlayerPrefs.GetInt("lvl"));
        FacebookManager.Instance.LevelCompleted(PlayerPrefs.GetInt("lvl"));
        AppMetricaPush.instance.SendLevelEnd(PlayerPrefs.GetInt("lvl"));
    }
    private void OnApplicationFocus(bool pause)
    {
        if (!pause)
        {
            AppMetrica.Instance.SendEventsBuffer();
        }
    }
    private void OnApplicationQuit()
    { 
        AppMetrica.Instance.SendEventsBuffer();
    }
}
