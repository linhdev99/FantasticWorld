using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public string item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(dialogActive && Input.GetKeyDown(KeyCode.X))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            dBox.SetActive(false);
            dialogActive = false;
            if (item == "Damage")
            {
                PlayerPrefs.SetInt("ItemDamage", 1);
            }
            else if (item == "HP")
            {
                PlayerPrefs.SetInt("ItemHP", 1);
            }
            else if (item == "EXP")
            {
                PlayerPrefs.SetInt("ItemEXP", 1);
            }
            else if (item == "Speed")
            {
                PlayerPrefs.SetInt("ItemSpeed", 1);
            }
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
