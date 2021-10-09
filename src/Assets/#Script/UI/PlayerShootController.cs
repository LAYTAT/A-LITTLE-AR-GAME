using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShootController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool can;

    private float delay;
    private float timer;

    private Ray ray;
    private RaycastHit hit;

    public GameObject origin;
    public GameObject body;
    public GameObject aim;

    void Start()
    {
        timer = -1f;
        can = false;
        delay = -123f;
    }
    
    void Update()
    {
        if (timer >= 0f)
            timer += Time.deltaTime;
        if (delay > 0f)
            delay -= Time.deltaTime;
        if(delay < 0f && delay != -123f)
        {
            delay = -123f;
            body.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerFightController.isHave() && PlayerFightController.GetBulletCount() > 0)
        {
            if (timer >= 1f || timer < 0f)
            {
                body.SetActive(false);
                aim.SetActive(true);
                can = true;
            }
        }
        else timer = -1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(can)
        {
            can = false;
            timer = 0f;
            PlayerFightController.Shoot();
            Shoot();
            delay = 1f;
            aim.SetActive(false);
        }
    }

    void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        ray.origin = origin.transform.position;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.tag.Equals("Enemy"))
            {
                BossController controller = hit.collider.GetComponent<BossController>();
                controller.Shoot();
            }
        }
    }

}
