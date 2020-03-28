using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {

    public string dialogue;
    public string item;
    private DialogueManager dMAn;
	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                dMAn.ShowBox(dialogue);
                dMAn.item = item;
            }
        }
    }
}
