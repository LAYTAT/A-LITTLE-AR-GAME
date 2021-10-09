using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool act;

    void Start()
    {
        act = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        act = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        act = false;
    }
}
