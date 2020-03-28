using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chatting : MonoBehaviour
{

    // Use this for initialization
    public Player player;
    [SerializeField]
    private ReadMission Mission;
    public GameObject dBOx;
    public Text dText;
    public GameObject GONPC { get; set; }
    public bool ChattingActive = false;
    public string textConr = "Congratulations, you completed the mission. This is some item which I want give you because of you efforts. Let's check your backpack again.";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()// 
    {
        if (ChattingActive && Input.GetKeyDown(KeyCode.X))
        {
            dBOx.SetActive(false);
            ChattingActive = false;
            if (dText.text != textConr)
            {
                getMission();
            }
        }
        
    }

    public void ShowBox(string dialogue)
    {
        ChattingActive = true;
        dBOx.SetActive(true);
        dText.text = dialogue;
    }
    public void getMission()
    {
        if (GONPC == null)
        {
            return;
        }
        if (GONPC.tag == "Mission")
        {
            Debug.Log(GONPC.name);
            if (PlayerPrefs.GetInt("CHECK_MISSION") == 1)
            {
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                bool isSuccess = player.CheckSuccessMission();
                if (isSuccess)
                {
                    ShowBox(textConr);
                }
                return;
            }
            if (GONPC.name == "Mission0")
            {
                PlayerPrefs.SetString("ID_MISSION", "M0");
            }
            else if (GONPC.name == "Mission1")
            {
                PlayerPrefs.SetString("ID_MISSION", "M1");
            }
            else if (GONPC.name == "Mission2")
            {
                PlayerPrefs.SetString("ID_MISSION", "M2");
            }
            else if (GONPC.name == "Mission3")
            {
                PlayerPrefs.SetString("ID_MISSION", "M3");
            }
            else if (GONPC.name == "Mission4")
            {
                PlayerPrefs.SetString("ID_MISSION", "M4");
            }
            else if (GONPC.name == "Mission5")
            {
                PlayerPrefs.SetString("ID_MISSION", "M5");
            }
            else if (GONPC.name == "Mission6")
            {
                PlayerPrefs.SetString("ID_MISSION", "M6");
            }
            else if (GONPC.name == "Mission7")
            {
                PlayerPrefs.SetString("ID_MISSION", "M7");
            }
            player.GetMission();
        }
    }

}
