using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReadMission : MonoBehaviour {
    public string[] ID;
    public string[] NAME;
    public int[] STATUS;
    public int[] MAX_COUNT;
    public int[] CUR_COUNT;
    public string PATH;
	void Start ()
    {
        ID = new string[8];
        NAME = new string[8];
        STATUS = new int[8];
        MAX_COUNT = new int[8];
        CUR_COUNT = new int[8];
    }
    void Update ()
    {
		
	}
    public void Change()
    {
        Writing();
        Reading();
    }
    public void Reading()
    {
        ID = new string[8];
        NAME = new string[8];
        STATUS = new int[8];
        MAX_COUNT = new int[8];
        CUR_COUNT = new int[8];

        PATH = "MISSION";
        string pattern = @"\[([^\[\]]+)\]";
        string pattern2 = @"\s[=]\s";
        string dirPath = Path.Combine(Application.dataPath, "Resources");
        string filepath = Path.Combine(dirPath, PATH + ".txt");
        StreamReader reader = new StreamReader(filepath);
        string input = reader.ReadToEnd();
        string[] elements = Regex.Split(input, pattern);
        int count = 0;
        foreach (Match m in Regex.Matches(input, pattern))
        {
            string[] elements2 = Regex.Split(m.Groups[1].Value, pattern2);
            Debug.Log(elements2.Length);
            if (elements2[1] == "")
            {
                reader.Close();
                ReReading();
                break;
            }
            else
            {
                ID[count] = elements2[0];
                NAME[count] = elements2[1];
                STATUS[count] = Convert.ToInt32(elements2[2]);
                MAX_COUNT[count] = Convert.ToInt32(elements2[3]);
                CUR_COUNT[count] = Convert.ToInt32(elements2[4]);
                count++;
            }
        }
        reader.Close();
    }
    public void Writing()
    {
        PATH = "MISSION";
        string dirPath = Path.Combine(Application.dataPath, "Resources");
        string filepath = Path.Combine(dirPath, PATH + ".txt");
        StreamWriter writer = new StreamWriter(filepath);
        for (int i = 0; i < 8; i++)
        {
            writer.WriteLine("[M" + i.ToString() + " = " + NAME[i] + " = " + STATUS[i] + " = " + MAX_COUNT[i] + " = " + CUR_COUNT[i] + "]");
        }
        writer.Close();
    }
    public void ReReading()
    {
        ID = new string[8];
        NAME = new string[8];
        STATUS = new int[8];
        MAX_COUNT = new int[8];
        CUR_COUNT = new int[8];
        string pattern = @"\[([^\[\]]+)\]";
        string pattern2 = @"\s[=]\s";
        string dirPath = Path.Combine(Application.dataPath, "Resources");
        string filepath = Path.Combine(dirPath, "NEW_MISSION.txt");
        StreamReader reader = new StreamReader(filepath);
        string input = reader.ReadToEnd();
        string[] elements = Regex.Split(input, pattern);
        int count = 0;
        foreach (Match m in Regex.Matches(input, pattern))
        {
            string[] elements2 = Regex.Split(m.Groups[1].Value, pattern2);
            ID[count] = elements2[0];
            NAME[count] = elements2[1];
            STATUS[count] = Convert.ToInt32(elements2[2]);
            MAX_COUNT[count] = Convert.ToInt32(elements2[3]);
            CUR_COUNT[count] = Convert.ToInt32(elements2[4]);
            count++;
        }
        reader.Close();
        Writing();
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.readMissionAll();
    }
}
