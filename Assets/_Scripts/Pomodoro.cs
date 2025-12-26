using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI CountDownText;
    [Header("Buttons")]
    [SerializeField] Button StartButton;
    [SerializeField] Button ResetButton;
    [SerializeField] Button IncreaseButton;
    [SerializeField] Button DecreaseButton;

    float minutes;
    float seconds;

    bool isCounting = false;

    private void Awake()
    {
        StartButton.onClick.AddListener(() =>
        {
            isCounting = !isCounting;
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
