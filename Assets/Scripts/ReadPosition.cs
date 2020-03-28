using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadPosition : MonoBehaviour {

    // Use this for initialization
    public float START_0_X;
    public float START_0_Y;
    public float START_1_X;
    public float START_1_Y;
    public float START_2_X;
    public float START_2_Y;
    public float START_3_X;
    public float START_3_Y;
    public float M0_1_X;
    public float M0_1_Y;
    public float M0_2_X;
    public float M0_2_Y;
    public float M0_3_X;
    public float M0_3_Y;

    void Start ()
    {
        ReadString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void ReadString()
    {
        string PATH = "POSITION_PLAYER";
        string pattern = @"\[([^\[\]]+)\]";
        string pattern2 = @"\s[=]\s";
        string dirPath = Path.Combine(Application.dataPath, "Resources");
        string filepath = Path.Combine(dirPath, PATH + ".txt");
        StreamReader reader = new StreamReader(filepath);
        //Debug.Log(reader.ReadToEnd());
        string input = reader.ReadToEnd();
        string[] elements = Regex.Split(input, pattern);
        foreach (Match m in Regex.Matches(input, pattern))
        {
            //Debug.Log(m.Groups[1].Value);
            string[] elements2 = Regex.Split(m.Groups[1].Value, pattern2);
            setData(elements2[0], float.Parse(elements2[1]));
        }
        //read.Close();
        reader.Close();
    }
    public void setData(string str, float data)
    {
        //Debug.Log(str + ": " + data);
        switch (str)
        {
            case "START_0_X": { START_0_X = data; return; }
            case "START_0_Y": { START_0_Y = data; return; }
            case "START_1_X": { START_1_X = data; return; }
            case "START_1_Y": { START_1_Y = data; return; }
            case "START_2_X": { START_2_X = data; return; }
            case "START_2_Y": { START_2_Y = data; return; }
            case "START_3_X": { START_3_X = data; return; }
            case "START_3_Y": { START_3_Y = data; return; }
            case "M0_1_X": { M0_1_X = data; return; }
            case "M0_1_Y": { M0_1_Y = data; return; }
            case "M0_2_X": { M0_2_X = data; return; }
            case "M0_2_Y": { M0_2_Y = data; return; }
            case "M0_3_X": { M0_3_X = data; return; }
            case "M0_3_Y": { M0_3_Y = data; return; }
            default: break;
        }
    }
}
