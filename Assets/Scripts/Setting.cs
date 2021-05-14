using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject[] ToPlay_Drag;
    [SerializeField] GameObject _partycle;
    [SerializeField] StartPlayer _startPlayer;
    //[ColorUsage(true, true)]
    //public Color _colorIon;
    public float minimum, maximum;
    private bool tap;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("lvl"))
        {
SceneManager.LoadScene(PlayerPrefs.GetInt("lvl"));
        }
        
    }
    private void Update()
    {
        if (!tap)
        {
        ToPlay_Drag[0].transform.localScale = new Vector2(Mathf.PingPong(Time.time/2, maximum - minimum) + minimum, Mathf.PingPong(Time.time/2, maximum - minimum) + minimum);
        }
        else
        {
        ToPlay_Drag[1].transform.localScale = new Vector2(Mathf.PingPong(Time.time/2, maximum - minimum) + minimum, Mathf.PingPong(Time.time/2, maximum - minimum) + minimum);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (tap)
            {
                ToPlay_Drag[1].SetActive(false);
                this.enabled = false;
            }
            else
            {
                ToPlay_Drag[1].SetActive(true);
            }
            ToPlay_Drag[0].SetActive(false);
            tap = true;
            _startPlayer.enabled = true;
            _partycle.SetActive(true);
        }
    }
}
