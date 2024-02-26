using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOverlay : MonoBehaviour
{
    [SerializeField] private Color color;

    [Space]
    [SerializeField] private Text[] texts;
    [SerializeField] private Image[] images;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Text scoreText;

    [Space]
    [SerializeField] private Transform backgr;
    [SerializeField] private Transform score;
    [SerializeField] private Transform next;

    private AudioSource scoreAudio;

    private int increaseScore = 237;


    private void Awake()
    {
        foreach (var item in texts)
        {
            item.color = color;
        }
        foreach (var item in images)
        {
            item.color = color;
        }
        foreach (var item in buttons)
        {
            var colors = item.colors;
            colors.normalColor = color;
            item.colors = colors;
        }
        scoreAudio = GetComponent<AudioSource>();

        backgr.localScale = Vector3.zero;
        score.localScale = Vector3.zero;
        next.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        Portal.OnPortal += OnPortal;
    }
    private void OnDisable()
    {
        Portal.OnPortal -= OnPortal;
    }

    private void OnPortal() => StartCoroutine(CountScoreCoroutine());
    private IEnumerator CountScoreCoroutine()
    {
        yield return new WaitForEndOfFrame();
        backgr.DOScale(Vector3.one, .5f);

        yield return new WaitForSeconds(.4f);
        score.DOScale(Vector3.one, .5f);

        yield return new WaitForSeconds(.3f);
        next.DOScale(Vector3.one, .5f);

        yield return new WaitForSeconds(.5f);
        int currentScore = 0;
        int finalScore = 0;

        if (PlayerPrefs.HasKey("scoreText"))
            currentScore = PlayerPrefs.GetInt("scoreText");

        finalScore = currentScore + increaseScore;

        PlayerPrefs.SetInt("scoreText", finalScore);
        PlayerPrefs.Save();

        while (currentScore < finalScore)
        {
            scoreText.text = currentScore.ToString();
            currentScore++;
            scoreAudio.Play();
            yield return null;
        }
    }

    private void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("scoreText").ToString();
    }
}
