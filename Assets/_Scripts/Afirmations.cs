using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Afirmations : ButtonScript
{
    [SerializeField] Button NewQuoteButton;
    [SerializeField] TextMeshProUGUI QuoteText;
    [SerializeField] List<string> QuotesList;


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
    }
    private void UpdateQuoteUI()
    {
        QuoteText.text = QuotesList[Random.Range(0, QuotesList.Count - 1)];
    }
}
