using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPunchAnimationController : MonoBehaviour, IPointerDownHandler
{
    public static bool punching;

    private float gap;
    private float now;

    public Animator action;

    void Start()
    {
        punching = false;
        gap = 1f;
        now = 0f;
    }

    void FixedUpdate()
    {
        if (PlayerFightController.isStop())
            return;
        if (punching)
        {
            now += Time.deltaTime;
            if (now >= gap)
            {
                punching = false;
                action.SetBool("Punching", false);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!punching && !PlayerKickAnimationController.kicking)
        {
            now = 0f;
            punching = true;
            action.SetBool("Punching", true);
        }
    }

}
