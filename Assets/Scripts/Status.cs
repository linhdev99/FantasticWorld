using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {

    private Image content;
    public float MyMaxValue { get; set; }

    private float currentFill;

    public float currentValue;

    public float myCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > myCurrentValue)
            {
                currentValue = MyMaxValue;
            }
            else if(value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
        }
    }


    // Use this for initialization
    void Start () {
        MyMaxValue = 100;   
        content = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(myCurrentValue);
	}

    public void Inialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        myCurrentValue = currentValue;
    }
}
