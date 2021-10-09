using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerManager : MonoBehaviour
{
	#region Singleton

	public static ARPlayerManager instance;

    void Awake(){
    	instance = this;
    }
    #endregion

    public GameObject player;
}
