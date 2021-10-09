using UnityEngine;


public class ARThirdPersonController : MonoBehaviour
{
    private float dx;
    private float dy;
    private float Total;
    public CharacterController killer;
    private Touch touch;
    private Vector2 origin;
    void Start()
    {
      //  killer.attachedRigidbody.useGravity = false;
        dx = 0f;
        dy = 0f;
        Total = 0f;
        Input.multiTouchEnabled = true;
    }

    void Update()
    {
        if (PlayerFightController.isStop() || Input.touchCount == 0)
            return;

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
               transform.Rotate(0f, dx, 0f);
        }
        origin = touch.position;
    }

    public void PlaceCharacter() {
        transform.localPosition = Vector3.zero;
    }

    
}
