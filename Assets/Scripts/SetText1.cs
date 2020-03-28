using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetText1 : MonoBehaviour
{
    //[SerializeField]
    private TextMeshProUGUI content;
    void Start()
    {
        content = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        
    }
    public void setText(string text)
    {
        if (content == null)
        {
            //Debug.Log("Content = NULL");
            return;
        }
        content.text = text;
    }
}
