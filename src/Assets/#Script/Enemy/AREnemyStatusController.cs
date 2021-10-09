using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AREnemyStatusController : MonoBehaviour
{
    public Slider sliderForBlood;
    private bool isGettingHit;
    public Animator EnemyAnimation;
    private float period;
    private int blood;
    private bool dead;
    //private float timer;
    private float shoot;
    public Text text;
    private float gap;
    private float now;

    // Start is called before the first frame update
    void Start()
    {
        blood = 100;
     //   timer = -1f;
        dead = false;
        shoot = 0f;
        period = 0f;

        //isDead gap
        gap = 0.33f;
        now = 0f;
        sliderForBlood.value = 1;
    }
    // Update is called once per frame
    void Update()
    {

        if (PlayerFightController.isDead()) {
            EnemyAnimation.SetBool("isBiting", true);
            text.text = "You are LOST & EATEN!";
        }
        if (blood <= 0) {
            dead = true;
            EnemyAnimation.SetBool("isGettingHit", false);
            EnemyAnimation.SetBool("isDead", true);
            text.text = "You Win!";
            if (dead)
            {
                now += Time.deltaTime;
                if (now >= gap)
                {
                    dead = false;
                    EnemyAnimation.SetBool("isDead", false);
                    EnemyAnimation.SetBool("isGameEnded", true);
                }
            }
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("AttackRange"))
        {
            Debug.Log("Enemy is getting attacked");
            if (period >= 0f)
            {
                period += Time.deltaTime;
                if (period <= 1.2f)
                    return;
            }
            if (ARPlayerPunchAnimationController.punching)
            {
                blood -= 10;
                sliderForBlood.value = (float)blood / 100;
                Debug.Log("Punch: blood: " + blood);
                period = 0f;
                EnemyAnimation.SetBool("isGettingHit", true);
            }
            else if (ARPlayerKickAnimationController.kicking)
            {
                blood -= 20;
                sliderForBlood.value = (float)blood / 100;
         //       Debug.Log("Kick: sliderForBlood.value" + sliderForBlood.value);
                period = 0f;
                EnemyAnimation.SetBool("isGettingHit", true);
            }
            else
            {
                period = -1f;
                EnemyAnimation.SetBool("isGettingHit", false);
            }
        }
    }

}
