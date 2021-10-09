using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpAnimationController : MonoBehaviour, IPointerDownHandler
{
    public static bool jumping;

    private float Vy;
    private float Vg;
    private float Dy;

    private Vector3 vector;

    private CollisionFlags flag;

    public Animator action;
    public CharacterController motion;

    void Start()
    {
        jumping = false;
        Vy = 0f; Vg = 0f; Dy = 0f;
        vector = new Vector3();
    }

    void Update()
    {
        if (PlayerFightController.isStop())
            return; // 游戏停止

        vector.y = Vy;
        Vg += 0.5f * Time.deltaTime; // 模拟重力
        Vy -= Vg; // 改变垂直速度

        float dy = motion.transform.position.y;
        vector *= Time.deltaTime; // 理论下落距离
        flag = motion.Move(vector);
        dy = motion.transform.position.y - dy; // 实际下落距离
        if (vector.y < 0f && dy - vector.y < 0.001f)
            Dy -= vector.y; // 实际下落与理论下落相等则更新下落距离

        if (flag == CollisionFlags.Below)
        { // 触碰地面
            if (Dy > 2f) // 掉落伤害 [2f - 8f]
                PlayerFightController.ChangeHP(-0.001f * Mathf.Exp(Dy));
            Vy = 0f; Vg = 0f; Dy = 0f; // 重置数据
            jumping = false;
            action.SetBool("Jumping", false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!jumping)
        {
            Vy = 2.5f;
            Vg = 0f;
            jumping = true;
            action.SetBool("Jumping", true);
            vector = transform.TransformDirection(vector);
        }
        else action.SetBool("Jumping", false);
    }

}
