using UnityEngine;
using UnityEngine.EventSystems;

public class AltButtonView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool Alt;

    public GameObject killer;

    void Start()
    {
        Alt = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Alt = true;
        killer.transform.localPosition = Vector3.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Alt = false;
    }

}
