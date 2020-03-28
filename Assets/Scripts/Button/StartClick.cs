using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartClick : MonoBehaviour
{
    public GameObject StartGO;
    public void Click(GameObject gO)
    {
        gO.SetActive(false);
        StartGO.SetActive(true);
    }
}
