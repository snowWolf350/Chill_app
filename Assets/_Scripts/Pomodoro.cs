using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : ButtonScript
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI CountDownText;
    [Header("Buttons")]
    [SerializeField] Button PlayButton;
    [SerializeField] Button ResetButton;
    [SerializeField] Button IncreaseButton;
    [SerializeField] Button DecreaseButton;
    [Header("Play Toggle")]
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite playSprite;

    float minutes;
    float seconds;

    bool isCounting = false;

    protected override void Awake()
    {
        base.Awake();
        PlayButton.onClick.AddListener(() =>
        {
            isCounting = !isCounting;
            if (isCounting)
            {
                PlayButton.image.sprite = pauseSprite;
            }
            else
            {
                PlayButton.image.sprite = playSprite;
            }
        });
        ResetButton.onClick.AddListener(() =>
        {
            minutes = 25;
            seconds = 0;
            UpdateCountDownUI();
        });
        IncreaseButton.onClick.AddListener(() =>
        {
            minutes += 5;
            UpdateCountDownUI();
        });
        DecreaseButton.onClick.AddListener(() =>
        {
            if(minutes>5)
            minutes -= 5;
            UpdateCountDownUI();
        });
    }

    private void Start()
    {
        minutes = 25;
        seconds = 0;
        UpdateCountDownUI();
    }
    private void Update()
    {
        if(isCounting)
        Countdown();
    }

    private void Countdown()
    {
        seconds -= Time.deltaTime;
        UpdateCountDownUI();
        if (seconds < 0 && minutes > 0)
        {
            minutes--;
            seconds = 60;
            UpdateCountDownUI();
        }
    }
    private void UpdateCountDownUI()
    {
        CountDownText.text = String.Concat(minutes.ToString(), ":", seconds.ToString("F0"));
        if(seconds <1)
        CountDownText.text = String.Concat(minutes.ToString(), ":", "00");
    }
}
