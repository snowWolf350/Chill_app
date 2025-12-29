using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Afirmations : ButtonScript
{
    [SerializeField] Button NewQuoteButton;
    [SerializeField] TextMeshProUGUI QuoteText;
    [SerializeField] List<string> QuotesList;

    Animator animator;

    const string IS_OPEN = "isOpen";

    protected override void Awake()
    {
        base.Awake();
        NewQuoteButton.onClick.AddListener(() =>
        {
            //refresh quote
            UpdateQuoteUI();
        });
    }

    private void Start()
    {
        UpdateQuoteUI();
        base.OnTabClosed += Afirmations_OnTabClosed;
        base.OnTabToggled += Afirmations_OnTabToggled;
        animator = GetComponent<Animator>();
    }

    private void Afirmations_OnTabToggled(object sender, System.EventArgs e)
    {
        Animatewindow();
    }

    private void Afirmations_OnTabClosed(object sender, System.EventArgs e)
    {
        Animatewindow();
    }

    private void UpdateQuoteUI()
    {
        QuoteText.text = QuotesList[Random.Range(0, QuotesList.Count - 1)];
    }
    private void Animatewindow()
    {
        animator.SetBool(IS_OPEN, base.TemplateState);
    }
}
