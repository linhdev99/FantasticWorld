using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    //[SerializeField]
    private Text content;
    public string myValue;
    void Start()
    {
        content = GetComponent<Text>();
    }
    void Update()
    {
        content.text = myValue;
    }
    public void setText(string text)
    {
        myValue = text;
    }
}
