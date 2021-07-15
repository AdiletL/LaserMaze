using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMetricaManager : MonoBehaviour
{
    public static AppMetricaManager Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void SendLevelFinish(int lvl) 
    {
        Dictionary<string,object> tutParams = new Dictionary<string, object>();
        tutParams["Level Number"] = lvl;
        Debug.Log(lvl);    
    }
}
