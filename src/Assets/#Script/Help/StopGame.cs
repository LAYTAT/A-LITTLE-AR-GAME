using UnityEngine;
using UnityEngine.EventSystems;

public class StopGame : MonoBehaviour, IPointerDownHandler
{
    public bool state;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(state != PlayerFightController.isStop())
            PlayerFightController.StopGame(state);
    }
}
