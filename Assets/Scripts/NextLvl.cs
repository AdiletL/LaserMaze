using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{

    int lvl=0;
   public void NextLevel() 
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
        }
        GamManager.instance.OnLevelCompleted(PlayerPrefs.GetInt("lvl"));
        FacebookManager.Instance.LevelCompleted(PlayerPrefs.GetInt("lvl"));
    }
   public void Restart() { SceneManager.LoadScene(PlayerPrefs.GetInt("lvl")); }
}
