using UnityEngine;
using UnityEngine.EventSystems;

public class ARPlayerReposition : MonoBehaviour, IPointerDownHandler
{
    private bool isExist=false;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject GrassPlayer;
    public GameObject GrassEnemy;
    public GameObject plane;
    public GameObject TargetImage;
    private Vector3 PlaneOriginalPosition;


    private Vector3 PlayerOriginalPosition;
    private Vector3 EnemyOriginalPosition;
    void Start()
    {
        PlaneOriginalPosition = TargetImage.transform.position;
        PlayerOriginalPosition = GrassPlayer.transform.position;
        EnemyOriginalPosition = GrassEnemy.transform.position;
        Debug.Log("GrassEnemy");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        plane.transform.position = TargetImage.transform.position;
        Debug.Log("Moved!");

        //  if (!isExist)   
        //{
        Player.transform.position = EnemyOriginalPosition;
        Enemy.transform.position = EnemyOriginalPosition;
        //      isExist = !isExist;
        //  }
        // else
        //  {
        //       Player.SetActive(false);
        //       isExist = !isExist;
        //     }

    }
}
