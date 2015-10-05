using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public ActionManager actionMan = null;
	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    public void StartSpawn()
    {
        Debug.Log("[SpawnScript] Start Spawn");
        if(null != actionMan)
        {
            actionMan.SetAction(ACTIONS.SPAWN);
        }
    }
}
