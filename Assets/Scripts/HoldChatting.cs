using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldChatting : MonoBehaviour
{

    public string dialogue;
    private Chatting dMan;
    [SerializeField]
    private GameObject GOdMan;
    [SerializeField]
    private Player player;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<Chatting>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                dMan.ShowBox(dialogue);
                dMan.GONPC = GOdMan;
                dMan.player = player;
            }            
        }
    }
}
