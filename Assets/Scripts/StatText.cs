using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatText : MonoBehaviour {

    private Text content;
    private float currentFill;
    public float myMaxValue
    {
        get;
        set;
    }
    private float currentValue;
    public float myCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > myMaxValue)
            {
                currentValue = myMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / myMaxValue;
        }
    }
    void Start()
    {
        content = GetComponent<Text>();
    }
    void Update()
    {
        //Debug.Log(myCurrentValue);
        content.text = Mathf.RoundToInt(currentFill * 100).ToString() + "%";
    }
    public void Initialized(float currentValue, float maxValue)
    {
        myMaxValue = maxValue;
        myCurrentValue = currentValue;
    }
}
