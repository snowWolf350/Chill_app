using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject[] Template;
    [SerializeField] Button toggleButton;
    [SerializeField] Button closeButton;

    protected bool TemplateState = true;

    public event EventHandler OnTabClosed;
    public event EventHandler OnTabToggled;
    protected virtual void Awake()
    {
        toggleButton.onClick.AddListener(() =>
        {
            TemplateState = !TemplateState;
            foreach (GameObject GO in Template)
            {
                GO.SetActive(TemplateState);
            }
            OnTabToggled?.Invoke(this, EventArgs.Empty);
        });
        closeButton.onClick.AddListener(() =>
        {
            TemplateState = false;
            foreach (GameObject GO in Template)
            {
                GO.SetActive(false);
            }
            OnTabClosed?.Invoke(this, EventArgs.Empty);
        });
    }
}
