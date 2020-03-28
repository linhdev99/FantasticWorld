using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Text;

public class ChangeData : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    public string PATH { get; set; }
    public float HEALTH;
    public float MAX_HEALTH;
    public float LEVEL;
    public float EXP;
    public float MAX_EXP;
    public float DAMAGE_0;
    public float DAMAGE_1;
    public float DAMAGE_2;
    public float DAMAGE_3;
    public float DAMAGE_4;
    public float SPEED;
    public float GOLD;
    public float TIME_SKIIL_1;
    public float TIME_SKIIL_2;
    public float TIME_SKIIL_3;
    public float TIME_SKIIL_4;
    public float ITEM_1;
    public float ITEM_2;
    public float ITEM_3;
    public float ITEM_4;
    public float MAP { get; set; }
    public float POSX { get; set; }
    public float POSY { get; set; }

    void Start()
    {
        //PATH = PlayerPrefs.GetString("PATH_DATA_PLAYER");
        //PATH = PATH;
        ReadString();
    }
    void Update()
    {
        //PATH = PATH;
        //PATH = PlayerPrefs.GetString("PATH_DATA_PLAYER");
        //WriteString();
        //ReadString();
    }
    public void Change()
    {
        WriteString();
        ReadString();
    }
    //[MenuItem("Tools/Write file")]
    public void WriteString()
    {
        //string PATH_SAVE = "DATA_PLAYER";
        // TextAsset asset = (TextAsset)Resources.Load(PATH_SAVE);
        //StringReader read = new StringReader(asset.text);
        //StringWriter writer = new StringWriter(sb);
        //string PATH_SAVE = "Assets/Resources/DATA_PLAYER.txt";

        //Write some text to the test.txt file
        string dirPath = Path.Combine(Application.dataPath, "Resources");
        string filepath = Path.Combine(dirPath, "DATA_PLAYER.txt");
        //TextAsset asset = Resources.Load("DATA_PLAYER") as TextAsset;
        StreamWriter writer = new StreamWriter(filepath);

        writer.WriteLine("[HEALTH = " + HEALTH + "]");
        writer.WriteLine("[MAX_HEALTH = " + MAX_HEALTH + "]");
        writer.WriteLine("[LEVEL = " + LEVEL + "]");
        writer.WriteLine("[EXP = " + EXP + "]");
        writer.WriteLine("[MAX_EXP = " + MAX_EXP + "]");
        writer.WriteLine("[DAMAGE_0 = " + DAMAGE_0 + "]");
        writer.WriteLine("[DAMAGE_1 = " + DAMAGE_1 + "]");
        writer.WriteLine("[DAMAGE_2 = " + DAMAGE_2 + "]");
        writer.WriteLine("[DAMAGE_3 = " + DAMAGE_3 + "]");
        writer.WriteLine("[DAMAGE_4 = " + DAMAGE_4 + "]");
        writer.WriteLine("[TIME_SKILL_1 = " + TIME_SKIIL_1 + "]");
        writer.WriteLine("[TIME_SKILL_2 = " + TIME_SKIIL_2 + "]");
        writer.WriteLine("[TIME_SKILL_3 = " + TIME_SKIIL_3 + "]");
        writer.WriteLine("[TIME_SKILL_4 = " + TIME_SKIIL_4 + "]");
        writer.WriteLine("[SPEED = " + SPEED + "]");
        writer.WriteLine("[GOLD = " + GOLD + "]");
        writer.WriteLine("[MAP = " + MAP + "]");
        writer.WriteLine("[POSITION_X = " + POSX + "]");
        writer.WriteLine("[POSITION_Y = " + POSY + "]");
        writer.WriteLine("[ITEM_1 = " + ITEM_1 + "]");
        writer.WriteLine("[ITEM_2 = " + ITEM_2 + "]");
        writer.WriteLine("[ITEM_3 = " + ITEM_3 + "]");
        writer.WriteLine("[ITEM_4 = " + ITEM_4 + "]");
        //writer.Flush();
        writer.Close();
        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(PATH_SAVE);
        //TextAsset asset = Resources.Load(PATH_SAVE) as TextAsset;
        //if (asset == null)
        //{
        //   Debug.Log("Can't open file data!\nPATH: " + PATH_SAVE);
        //  return;
        //}
        //Print the text from the file
        //Debug.Log(asset.text);
        //Debug.Log(POSX + "\n" + POSY);
        //Debug.Log("Save success...");
    }
    //[MenuItem("Tools/Read file")]
    public void ReadString()
    {
        PATH = PlayerPrefs.GetString("PATH_DATA_PLAYER");
        //Debug.Log(PATH);
        //string path = "Assets/Resources/DATA_PLAYER.txt";
        string pattern = @"\[([^\[\]]+)\]";
        string pattern2 = @"\s[=]\s";
        //Read the text from directly from the test.txt file
        //AssetDatabase.ImportAsset(PATH);
        //TextAsset asset = (TextAsset)Resources.Load(PATH);
        //if (asset == null)
        //{
        //    Debug.Log("Can't open file data!\nPATH: " + PATH);
        //    return;
        //}
        //StringReader read = new StringReader(asset.text);
        //string input = read.ReadToEnd();
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
        if (PATH == "NEW_DATA_PLAYER")
        {
            WriteString();
            PlayerPrefs.SetString("PATH_DATA_PLAYER", "DATA_PLAYER");
        }
    }
    public void setData(string str, float data)
    {
        //Debug.Log(str + ": " + data);
        switch (str)
        {
            case "HEALTH": { HEALTH = data; return; }
            case "MAX_HEALTH": { MAX_HEALTH = data; break; }
            case "LEVEL": { LEVEL = data; break; }
            case "EXP": { EXP = data; break; }
            case "MAX_EXP": { MAX_EXP = data; break; }
            case "DAMAGE_0": { DAMAGE_0 = data; break; }
            case "DAMAGE_1": { DAMAGE_1 = data; break; }
            case "DAMAGE_2": { DAMAGE_2 = data; break; }
            case "DAMAGE_3": { DAMAGE_3 = data; break; }
            case "DAMAGE_4": { DAMAGE_4 = data; break; }
            case "TIME_SKILL_1": { TIME_SKIIL_1 = data; break; }
            case "TIME_SKILL_2": { TIME_SKIIL_2 = data; break; }
            case "TIME_SKILL_3": { TIME_SKIIL_3 = data; break; }
            case "TIME_SKILL_4": { TIME_SKIIL_4 = data; break; }
            case "SPEED": { SPEED = data; break; }
            case "GOLD": { GOLD = data; break; }
            case "MAP": { MAP = data; break; }
            case "POSITION_X": { POSX = data; break; }
            case "POSITION_Y": { POSY = data; break; }
            case "ITEM_1": { ITEM_1 = data; break; }
            case "ITEM_2": { ITEM_2 = data; break; }
            case "ITEM_3": { ITEM_3 = data; break; }
            case "ITEM_4": { ITEM_4 = data; break; }
            default: break;
        }
    }
}
