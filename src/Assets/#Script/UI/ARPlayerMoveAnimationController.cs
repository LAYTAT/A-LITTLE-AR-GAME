using UnityEngine;
using UnityEngine.EventSystems;

public class ARPlayerMoveAnimationController : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    public GameObject Player;
    public float speed = 0.04f;
    public static int fingerID;

    private float x0, y0;

    private float dx, dy;

    private float Vx, Vy;

    private float unit;

    private Vector3 offset;
    private Vector3 target;

    public Animator action;
    public CharacterController motion;

    void Start()
    {
        fingerID = 2333;
        x0 = 0f; y0 = 0f;
        dx = 0f; dy = 0f;
        Vx = 0f; Vy = 0f;
        unit = 0.015625f;
        target = new Vector3();
        offset = transform.localPosition;
    }

    void Update()
    {

        if (PlayerFightController.isStop())
            return;
        if (PlayerJumpAnimationController.jumping)
        { // 跳跃中使用惯性
            Vx += (Vx == 0f) ? 0f : ((Vx > 0f) ? -1f : 1f) * unit;
            Vy += (Vy == 0f) ? 0f : ((Vy > 0f) ? -1f : 1f) * unit;
        }
        else
        {
            Vx = dx / 100f;
            Vy = dy / 100f;
        }
        target.Set(Vx * Time.deltaTime, 0,  (Vy > 0.7f ? 4f : (Vy > 0f ? 1.5f : 1f)) * Vy * Time.deltaTime);
        motion.Move(motion.transform.TransformDirection(target));
        action.SetFloat("H", Vx/speed);
        action.SetFloat("V", Vy/speed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        fingerID = eventData.pointerId;
        x0 = eventData.position.x;
        y0 = eventData.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dx =(eventData.position.x - x0)* speed;
        dy = (eventData.position.y - y0) * speed;
        float s = dx * dx + dy * dy;
        if (s <= 10000f)
            offset.Set(dx, dy, 0f);
        else
        {
            s = 100f / Mathf.Sqrt(s);
            offset.Set(dx = s * dx, dy = s * dy, 0f);
        }
        transform.localPosition = offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        fingerID = 2333; // id doesn't exist
        dx = 0f;
        dy = 0f;
        transform.localPosition = Vector3.zero;
    }
}

