using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuedClick : MonoBehaviour {

    [SerializeField]
    private ChangeData data_player;
    public string path_game;
    //public string PATH = "NEW_DATA_PLAYER";
    public void Click()
    {
        //data_player = new ChangeData();
        data_player.PATH = "DATA_PLAYER";
        //Debug.Log(data_player.PATH);
        //Debug.Log(data_player.MAP);
        PlayerPrefs.SetString("PATH_DATA_PLAYER", "DATA_PLAYER");
        //PlayerPrefs.SetString("PATH_DATA_PLAYER", "Assets/Resources/NEW_DATA_PLAYER.txt");
        data_player.ReadString();
        SceneManager.LoadScene("Map" + data_player.MAP);
    }
}
