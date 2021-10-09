using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    public GameObject[] buttons;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            for(int i = 0; i < 4; i++)
                if (EventSystem.current.currentSelectedGameObject == buttons[i])
                {
                    if (i == 1)
                    {
                        //UnityEditor.EditorApplication.isPlaying = false;
                        Application.Quit();
                    }
                }
    }
}
