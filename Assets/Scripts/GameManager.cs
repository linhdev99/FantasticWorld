using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private NPCs currentTarget;
	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickTarget();
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 256);
                if (hit.collider != null)
                {
                    //player.myTarget = hit.transform;
                    if (currentTarget != null)
                    {
                        //currentTarget.DeSelect();
                    }
                    //currentTarget = hit.collider.GetComponent<NPCs>();
                    //player.myTarget = hit.transform;
                }
                else
                {
                    //player.myTarget = null;
                    if (currentTarget != null)
                    {
                        //currentTarget.DeSelect();
                    }
                    //currentTarget = null;
                    //player.myTarget = null;
                }
            }
        }
    }        
}
