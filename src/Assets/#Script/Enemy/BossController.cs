using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    private bool dead;

    private int blood;
    private float timer;
    private float period;
    private float shoot;
    private Animator action;
    public GameObject treasure;
    public Text text;
    void Start()
    {
        dead = false;
        blood = 100;
        timer = -1f;
        shoot = 0f;
        period = 0f;
        action = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        if (dead)
            return;
        if (timer > 1.3f)
        {
            dead = true;
            gameObject.SetActive(false);
            transform.Translate(0f, 1f, 0f);
            treasure.transform.position = transform.position;
        }
        else if (timer >= 0f)
            timer += Time.deltaTime;
        else if (blood <= 0)
        {
            action.SetBool("Hiting", false);
            action.SetBool("Dying", true);
            timer = 0f;
            if (name.Equals("Boss3"))
                text.text = "You Win!";
        }
        else if (!(PlayerPunchAnimationController.punching || PlayerKickAnimationController.kicking))
        {
            if (shoot <= 0f)
                action.SetBool("Hiting", false);
            else
                shoot -= Time.deltaTime;
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("AttackRange"))
        {
            if (period >= 0f)
            {
                period += Time.deltaTime;
                if (period <= 1.2f)
                    return;
            }
            if (PlayerPunchAnimationController.punching)
            {
                blood -= 10;
                period = 0f;
                action.SetBool("Hiting", true);
            }
            else if (PlayerKickAnimationController.kicking)
            {
                blood -= 30;
                period = 0f;
                action.SetBool("Hiting", true);
            }
            else
            {
                period = -1f;
                action.SetBool("Hiting", false);
            }
        }
    }

    public void Shoot()
    {
        blood -= 50;
        shoot = 1f;
        action.SetBool("Hiting", true);
    }
}
