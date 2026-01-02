using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Afirmations : ButtonScript
{
    [SerializeField] Button NewQuoteButton;
    [SerializeField] TextMeshProUGUI QuoteText;
    [SerializeField] AffirmationSO affirmationSO;

    string currentQuote;
    string newQuote;

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

        do
        {
            newQuote = affirmationSO.AffirmationList[Random.Range(0, affirmationSO.AffirmationList.Count)];
        } while (newQuote == currentQuote);

        currentQuote = newQuote;

        QuoteText.text = currentQuote;
    }
}
