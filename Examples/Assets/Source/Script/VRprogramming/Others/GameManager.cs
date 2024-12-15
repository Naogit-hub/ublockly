using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameManager
{
    public static List<ProgrammableObject> p_ObjectList = new List<ProgrammableObject>();
    public static ProgrammableObject curObject = null;
    public static float flameRate = 120;
    public static void RegisterObject(ProgrammableObject p)
    {
        // Debug.Log(p.name); 
        p_ObjectList.Add(p);
        curObject = p;
        // Debug.Log(p.name + "aa"); 

        // StreamWriter writer;

        // string jsonstr = JsonUtility.ToJson(player);

        // writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        // writer.Write(jsonstr);
        // writer.Flush();
        // writer.Close();
    }

    public static ProgrammableObject GetObject(int num)
    {
        curObject = p_ObjectList[num];
        return curObject;
    }

}
