using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSingleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 shrinkScale = Vector3.one;
    [SerializeField]Vector3 expandScale = new Vector3(1.1f,1.1f,1.1f);

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        float timer = 0;
        float timerMax = 0.5f;

        while(timer < timerMax)
        {
            timer += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(shrinkScale, expandScale, timer*timer);
        }

        rectTransform.localScale = expandScale;

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        float timer = 0;
        float timerMax = 0.75f;

        while (timer < timerMax)
        {
            timer += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(expandScale, shrinkScale, timer*timer);
        }

        rectTransform.localScale = shrinkScale;
    }
}
