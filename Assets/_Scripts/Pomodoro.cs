using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : ButtonScript
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI CountDownText;
    [Header("Buttons")]
    [SerializeField] Button StartButton;
    [SerializeField] Button ResetButton;
    [SerializeField] Button IncreaseButton;
    [SerializeField] Button DecreaseButton;

    Animator animator;

    float minutes;
    float seconds;

    bool isCounting = false;

    const string IS_OPEN = "isOpen";

    protected override void Awake()
    {
        base.Awake();
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
        animator = GetComponent<Animator>();
        base.OnTabClosed += Pomodoro_OnTabClosed;
        base.OnTabToggled += Pomodoro_OnTabToggled;
    }

    private void Pomodoro_OnTabToggled(object sender, EventArgs e)
    {
        Animatewindow();
    }

    private void Pomodoro_OnTabClosed(object sender, EventArgs e)
    {
        Animatewindow();
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
    private void Animatewindow()
    {
        animator.SetBool(IS_OPEN, base.TemplateState);
    }
}
