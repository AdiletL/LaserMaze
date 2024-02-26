using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : MonoBehaviour
{
    public static GamManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }
}
