using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AREnemyAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator playerAnimator;
    int index = 0;
    int s_index = 0;
    float time = 0;

    void Start()
    {
        index = 0;
        s_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {   //玩家进入老鼠攻击范围内时开始计时
        time = 0;
    }

    void OnTriggerExit(Collider other)
    {   //玩家进入老鼠攻击范围内时开始计时
        time = 0;
    }

    void OnTriggerStay(Collider other)     //计时器
    {
        time += Time.deltaTime;
        index = index + 1;

        if (index == 50)
        {
            s_index = s_index + 1;
          //  Debug.Log("-------" + index + "????::" + s_index + "Time:" + time);
            index = 0;
        }

        if (playerAnimator.GetBool("isAttacking")) {    //如果正在攻击状态
            if (time >= 1)  //打中了玩家
            {
                if(!playerAnimator.GetBool("isGameEnded"))
                    PlayerFightController.ChangeHP(-0.05f); //扣血
                    //PlayerFightController.ChangeHP(-1f); //扣血
                time = 0;
            }
        }
    }


}
