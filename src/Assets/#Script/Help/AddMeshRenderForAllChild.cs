using UnityEngine;
//using UnityEditor;

public class AddMeshRenderForAllChild : MonoBehaviour
{
    //[MenuItem("AddCollider/AddMeshCollider")]
    void Start()
    {
        GameObject[] obj = FindObjectsOfType(typeof(GameObject)) as GameObject[]; //获取GameObject[] obj; //定义
        foreach (GameObject child in obj)    //遍历所有gameobject
        {
            if (child.layer == 8 && child.GetComponent<MeshRenderer>() != null &&
                child.GetComponent<MeshCollider>() == null)
                child.AddComponent<MeshCollider>();
        }
    }
}