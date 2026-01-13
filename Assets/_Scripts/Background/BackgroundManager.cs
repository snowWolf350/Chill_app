using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] BackgroundListSO backgroundListSO;
    [SerializeField] Button backgroundToggleButton;
    [SerializeField] Image[] darkBackground;
    [SerializeField] Image[] lightBackground;

    BackgroundSO currentbackgroundSO;
    BackgroundSO newbackgroundSO;

    Transform currentBackground;

    public static event EventHandler OnBackgroundChanged;
    private void Awake()
    {
        backgroundToggleButton.onClick.AddListener(() =>
        {
            changeBackground();
            OnBackgroundChanged?.Invoke(this, EventArgs.Empty);
        });
    }

    private void Start()
    {
        changeBackground();
    }

    private void changeBackground()
    {
        do
            newbackgroundSO = backgroundListSO.backgroundListSO[UnityEngine.Random.Range(0, backgroundListSO.backgroundListSO.Count)];
        while (newbackgroundSO == currentbackgroundSO);
        currentbackgroundSO = newbackgroundSO;

        if (currentBackground == null)
        {
            Transform backgroundTransform = Instantiate(currentbackgroundSO.background.transform);
            currentBackground = backgroundTransform;
            backgroundTransform.localPosition = Vector3.zero;
        }
        else
        {
            Destroy(currentBackground.transform.gameObject);
            Transform backgroundTransform = Instantiate(currentbackgroundSO.background.transform);
            currentBackground = backgroundTransform;
            backgroundTransform.localPosition = Vector3.zero;
        }

        foreach (Image image in darkBackground)
        {
            image.color = currentbackgroundSO.darkBackgroundColour;
        }
        foreach (Image image in lightBackground)
        {
            image.color = currentbackgroundSO.lightBackgroundColour;
        }
    }
}
