using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerKickAnimationController : MonoBehaviour, IPointerDownHandler
{
    public static bool kicking;

    private float gap;
    private float now;

    public Animator action;

    void Start()
    {
        kicking = false;
        gap = 1.1f;
        now = 0f;
    }

    void FixedUpdate()
    {
        if (PlayerFightController.isStop())
            return;
        if (kicking)
        {
            now += Time.deltaTime;
            if (now >= gap)
            {
                kicking = false;
                action.SetBool("Kicking", false);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!kicking &&
            !PlayerPunchAnimationController.punching &&
            PlayerFightController.ChangeMP(-0.1f))
        {
            now = 0f;
            kicking = true;
            action.SetBool("Kicking", true);
        }
    }
}
