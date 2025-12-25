using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject[] Template;
    [SerializeField] Button toggleButton;
    [SerializeField] Button closeButton;

    private bool TemplateState = true;
    private void Awake()
    {
        toggleButton.onClick.AddListener(() =>
        {
            TemplateState = !TemplateState;
            foreach (GameObject GO in Template)
            {
                GO.SetActive(TemplateState);
            }
        });
        closeButton.onClick.AddListener(() =>
        {
            TemplateState = false;
            foreach (GameObject GO in Template)
            {
                GO.SetActive(false);
            }
        });
    }
}
