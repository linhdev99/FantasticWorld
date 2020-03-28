using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutsClick : MonoBehaviour
{
    public GameObject aboutsGO;
    public void Click(GameObject gO)
    {
        gO.SetActive(false);
        aboutsGO.SetActive(true);
    }
}
