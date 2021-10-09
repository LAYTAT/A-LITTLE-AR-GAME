using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IntroductionTabSwitch : MonoBehaviour
{
    private int index;

    public Text content;

    public GameObject[] items;
    private string[] contents;

    void Start()
    {
        index = 0;
        contents = new string[5];
        for(int i = 0; i < 5; i++)
            contents[i] = Resources.Load<TextAsset>("Introduction" + (i + 1)).text;
        content.text = contents[0];
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            for (int i = 0; i < 5; i++)
                if (EventSystem.current.currentSelectedGameObject == items[i])
                {
                    if (i != index)
                    {
                        content.text = contents[i];
                        index = i;
                    }
                    break;
                }
    }
}
