using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int type;
    
    void Update()
    {
        transform.Rotate(Vector3.up, 50f * Time.deltaTime);
    }

    void OnTriggerStay(Collider collider)
    {
        if(InteractiveButton.act && collider.gameObject.name.Equals("AttackRange"))
        {
            switch(Mathf.Abs(type) % 3)
            {
                case 0: PlayerFightController.HaveAGun(); break;
                case 1: PlayerFightController.GetBullets(); break;
                case 2: PlayerFightController.ChangeHP(1f); break;
            }
            gameObject.SetActive(false);
        }
    }
}
