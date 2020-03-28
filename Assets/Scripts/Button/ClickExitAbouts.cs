using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExitAbouts : MonoBehaviour {

    public GameObject menuGO;
    public void Click(GameObject gO)
    {
        gO.SetActive(false);
        menuGO.SetActive(true);
    }
}
