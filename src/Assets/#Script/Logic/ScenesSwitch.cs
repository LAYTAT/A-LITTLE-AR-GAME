using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScenesSwitch : MonoBehaviour, IPointerDownHandler
{
    public float Max;

    public string SceneName;

    public RectTransform Bar;

    private Vector2 vector;

    private AsyncOperation operation;

    void Update()
    {
        if(operation != null && !operation.isDone)
        {
            vector.Set(operation.progress * Max - Max, 0f);
            Bar.offsetMax = vector;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        operation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        vector = Bar.offsetMax;
    }

}
