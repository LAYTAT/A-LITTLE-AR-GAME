using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class ARPlayerRightRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{

    public CharacterController player;
    public Animator ani;
    private bool isPointerDown =false;
    public int rotateSpeed = 16;

    private float durationThreshold = 0.2f;  //触发长按的时间限制

    private UnityEvent onLongPress = new UnityEvent();

   // private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;

    private void Update()
    {
        // if (isPointerDown && !longPressTriggered)
        //  {
        //     if (Time.time - timePressStarted > durationThreshold)
        //      {
        //          longPressTriggered = true;
        //          onLongPress.Invoke();
        //      }
        //   }
        if(isPointerDown)
        player.transform.RotateAround(player.transform.position, player.transform.up, rotateSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      //  timePressStarted = Time.time;
        isPointerDown = true;
        ani.SetBool("isRotating", true);
        //  longPressTriggered = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        ani.SetBool("isRotating", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerDown = false;
        ani.SetBool("isRotating", false);
    }

}