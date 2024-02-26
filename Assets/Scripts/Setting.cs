using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Setting : MonoBehaviour
{
    [SerializeField] GameObject[] ToPlay_Drag;
    [SerializeField] GameObject _partycle;
    [SerializeField] StartPlayer _startPlayer;

    public float minimum, maximum;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("lvl"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("lvl"));
        }
        //ToPlay_Drag[0].transform.DOScale(Vector3.one * .8f, .5f).SetLoops(10, LoopType.Yoyo);
        TurnOn();
    }
    private void TurnOn()
    {
        ToPlay_Drag[0].SetActive(false);
        _startPlayer._Player.SetActive(true);
        _startPlayer.Portal.SetActive(true);
        _partycle.SetActive(true);
        gameObject.SetActive(false);
    }
}
