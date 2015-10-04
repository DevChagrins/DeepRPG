using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BaseNode : MonoBehaviour
{
    public SpriteRenderer NodeFrame = null;

    public bool ChangeColor = false;
    public int ColorMode = 0;

    void Awake()
    {
        ChangeColor = true;
    }

	// Use this for initialization
	void Start()
    {
	}
	
	// Update is called once per frame
	void Update()
    {
        if(ChangeColor == true)
        {
            switch(ColorMode)
            {
                case 0:
                    {
                        ChangeOutlineColor(Color.white);
                        break;
                    }
                case 1:
                    {
                        ChangeOutlineColor(Color.blue);
                        break;
                    }
                case 2:
                    {
                        ChangeOutlineColor(Color.green);
                        break;
                    }
            }
            ChangeColor = false;
        }
	}

    private bool ChangeOutlineColor(Color newColor)
    {
        bool didChange = false;

        if (NodeFrame != null)
        {
            NodeFrame.color = newColor;
        }

        return didChange;
    }
}
