using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private float dx;
    private float dy;
    private float Total;

    private Touch touch;
    private Vector2 origin;

    public GameObject focus;
    public Camera MiniMapCamera;

    void Start()
    {
        dx = 0f;
        dy = 0f;
        Total = 0f;
        //Input.multiTouchEnabled = true;
    }
    
    void Update()
    {
        if (PlayerFightController.isStop() || Input.touchCount == 0)
            return;

        /***
        dx = Input.GetAxis("Mouse X");
        dy = Input.GetAxis("Mouse Y");
        if (AltButtonView.Alt)
            focus.transform.RotateAround(focus.transform.position, Vector3.up, dx);
        else
        {
            transform.Rotate(0f, dx, 0f);
            MiniMapCamera.transform.Rotate(0f, 0f, dx);
        }
        focus.transform.Rotate(dy, 0f, 0f);
        /****/

        
        if (Input.touchCount == 1)
        {
            if (PlayerMoveAnimationController.fingerID != 0)
                touch = Input.touches[0];
        }
        else
            touch = Input.touches[(PlayerMoveAnimationController.fingerID + 1) % 2];
        if (touch.phase == TouchPhase.Ended)
            return;

        if (touch.phase == TouchPhase.Moved)
        {
            dx = (touch.position.x - origin.x) / 2;
            dy = (touch.position.y - origin.y) / 2;
            if (AltButtonView.Alt)
                focus.transform.RotateAround(focus.transform.position, Vector3.up, dx);
            else
            {
                transform.Rotate(0f, dx, 0f);
                MiniMapCamera.transform.Rotate(0f, 0f, dx);
            }
            Total += dy;
            if (Mathf.Abs(Total) > 60f)
                Total -= dy;
            else
                focus.transform.Rotate(-dy, 0f, 0f);
            //反转Y轴:  focus.transform.Rotate(dy, 0f, 0f);
        }
        origin = touch.position;
    }
}
