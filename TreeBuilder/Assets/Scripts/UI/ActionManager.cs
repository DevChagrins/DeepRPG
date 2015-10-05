using UnityEngine;
using System.Collections;

public enum ACTIONS
{
    NONE = 0,
    SPAWN,
    SELECT,
}
public class ActionManager : MonoBehaviour
{
    public GameObject NodeTemplate = null;
    public GameObject LinkNodeTemplate = null;

    public GameObject OriginObject = null;

    ACTIONS CurrentAction = ACTIONS.NONE;

    // Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	    if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("[ActionManager] Update - Right mouse button click");
            GameObject objectAtPoint = null;
            Vector3 checkPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Do some moving to snap to grid

            // Convert back to screen for rayness
            Vector3 newScreenPoint = Camera.main.WorldToScreenPoint(checkPosition);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(newScreenPoint), out hit))
            {
                if(null != hit.collider.gameObject)
                {
                    objectAtPoint = hit.collider.gameObject;
                }
            }

            DoAction(objectAtPoint, checkPosition);
        }
	}

    void DoAction(GameObject objectAtPoint, Vector3 position)
    {
        Debug.Log("[ActionManager] DoAction");

        bool actionCompleted = false;
        // Track Actions, any objects at point and the incoming position
        switch(CurrentAction)
        {
            case ACTIONS.NONE: 
                { 
                    break;
                }
            case ACTIONS.SPAWN:
                {
                    actionCompleted = TrySpawn(objectAtPoint, position);
                    break;
                }
            case ACTIONS.SELECT:
                {
                    break;
                }
        }

        if(true == actionCompleted)
        {
            Debug.Log("[ActionManager] Action Completed");

            CurrentAction = ACTIONS.NONE;
        }
    }

    bool TrySpawn(GameObject obj, Vector3 position)
    {
        Debug.Log("[ActionManager] TrySpawn");

        bool actionComplete = false;

        if(null == obj)
        {
            if(null != NodeTemplate)
            {
                if (null != OriginObject)
                {
                    GameObject newObject = (GameObject)GameObject.Instantiate(NodeTemplate, position, Quaternion.identity);
                    if(null != newObject)
                    {
                        newObject.transform.parent = OriginObject.transform;

                        // Adjust position for Z
                        Vector3 fixedPosition = newObject.transform.position;
                        fixedPosition.z = 0f;
                        newObject.transform.position = fixedPosition;

                        actionComplete = true;
                    }
                }
            }
        }

        return actionComplete;
    }

    public void SetAction(ACTIONS newAction)
    {
        Debug.Log("[ActionManager] SetAction");

        CurrentAction = newAction;
    }
}
