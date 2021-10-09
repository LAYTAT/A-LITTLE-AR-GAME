using UnityEngine;
using UnityEngine.UI;

public class PlayerFightController : MonoBehaviour
{
    private static bool Dead;
    private static bool Stop;
    private static bool Have;
    private static bool Plus;
    private static bool Lose;

    private static int BulletCount;

    private static float MAX;
    private static Vector2 HP;
    private static Vector2 MP;
    public RectTransform HPLength;
    public RectTransform MPLength;

    private int[] PropCount;
    public Button[] PropButton;
    public Text[] PropView;

    private float now;
    private float timer;
    public Animator action;
    public GameObject Player;

    void Start()
    {
        InitializeState();
        UpdateUIState();
        timer = 0f;

        PropButton[0].onClick.AddListener(OnClick_HP_Potion);
        PropButton[1].onClick.AddListener(OnClick_MP_Potion);
    }

    void Update()
    {
        if (Dead || Stop)
            return;

        if(HP.x + MAX < 1f)
        { // 玩家血条不足
           // Dead = true;
            PropView[3].text = "You Lose";
            action.SetBool("Dying", true);
            timer += Time.deltaTime;
            if (timer >=0.2f) {
                action.SetBool("Dying", false);
                Dead = true;
            }
              
        }

        now += Time.deltaTime;
        if(now >= 1f)
        { // 体力每秒自动恢复
            ChangeMP(0.009f);
            now = 0;
        }
        if(Plus)
        { // 添加子弹
            PropCount[2] += 10;
            BulletCount = PropCount[2];
            Plus = false;
        }
        if(Lose)
        { // 射击
            if(PropCount[2] > 0)
                PropCount[2]--;
            Lose = false;
            BulletCount = PropCount[2];
        }
        UpdateUIState();
    }

    void InitializeState()
    {
        Dead = false;
        Stop = false;
        Have = false;
        Plus = false;
        Lose = false;

        BulletCount = 0;

        MAX = 420f;
        HP = HPLength.offsetMax;
        MP = MPLength.offsetMax;

        PropCount = new int[3];
        for(int i = 0; i < 3; i++)
            PropCount[i] = 2;

        now = 0f;
    }

    void UpdateUIState()
    {
        HPLength.offsetMax = HP;
        MPLength.offsetMax = MP;

        for(int i = 0; i < 2; i++)
            PropView[i].text = "" + PropCount[i];
    }

    public static bool isDead()
    {
        return Dead;
    }

    public static bool isStop()
    {
        return Stop;
    }

    public static bool isHave()
    {
        return Have;
    }

    public static int GetBulletCount()
    {
        return BulletCount;
    }

    public static void StopGame(bool off)
    {
        Stop = off;
    }

    public static void HaveAGun()
    {
        Have = true;
    }

    public static void GetBullets()
    {
        Plus = true;
    }

    public static void Shoot()
    {
        Lose = true;
    }

    public static void ChangeHP(float dH)
    {
        dH *= MAX;
        dH += MAX + HP.x;
        HP.Set(dH > MAX ? 0f : (dH < 0f ? -MAX : dH - MAX), -30f);
    }

    public static bool ChangeMP(float dM)
    {
        dM *= MAX;
        dM += MAX + MP.x;
        if (dM < 0f)
            return false;
        MP.Set(dM > MAX ? 0f : dM - MAX, -30f);
        return true;
    }

    void OnClick_HP_Potion() {
        if (PropCount[0] != 0) {
            float addPortion = 0.20f;
            ChangeHP(addPortion);
            Debug.Log("HP added:" + addPortion);
            PropCount[0]--;
        }

    }

    void OnClick_MP_Potion() {
        if (PropCount[0] != 0)
        {
            float addPortion = 0.1f;
            ChangeHP(addPortion);
            Debug.Log("MP added:" + addPortion);
            PropCount[1]--;
        }
    }

}
