using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Afirmations : MonoBehaviour
{
    [SerializeField] Button NewQuoteButton;
    [SerializeField] TextMeshProUGUI QuoteText;
    [SerializeField] List<string> QuotesList;

    private void Awake()
    {
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
