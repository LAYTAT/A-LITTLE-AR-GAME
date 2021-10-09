using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooseButton : MonoBehaviour
{
    public GameObject buttonObjToBeRemove;
    public GameObject[] levelChoiceButtonObjs;
    // Start is called before the first frame update
    void Start()
    {
        Button buttonToBeRemoved = buttonObjToBeRemove.GetComponent<Button>();
        buttonToBeRemoved.onClick.AddListener(onclick_removeBtn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void onclick_removeBtn() {
        buttonObjToBeRemove.SetActive(false);
        foreach (GameObject gameObject in levelChoiceButtonObjs)
            gameObject.SetActive(true);
    }
}
