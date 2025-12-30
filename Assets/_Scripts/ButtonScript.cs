using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject[] Template;
    [SerializeField] Button toggleButton;
    [SerializeField] Button closeButton;

    protected bool TemplateState = true;
    private const string IS_OPEN = "isOpen";
       
    public event EventHandler OnTabClosed;
    public event EventHandler OnTabToggled;

    Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        toggleButton.onClick.AddListener(() =>
        {
            TemplateState = !TemplateState;
            animator.SetBool(IS_OPEN, TemplateState);
            foreach (GameObject GO in Template)
            {
                GO.SetActive(TemplateState);
            }
            OnTabToggled?.Invoke(this, EventArgs.Empty);
        });
        closeButton.onClick.AddListener(() =>
        {
            TemplateState = false;
            animator.SetBool(IS_OPEN, TemplateState);
            foreach (GameObject GO in Template)
            {
                GO.SetActive(false);
            }
            OnTabClosed?.Invoke(this, EventArgs.Empty);
        });
    }
}
