using UnityEngine;

public class OutOfMapRange : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player") && !PlayerFightController.isDead())
            PlayerFightController.ChangeHP(-1f);
    }
}
