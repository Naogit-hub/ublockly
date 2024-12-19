using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public List<ProgrammableObject> p_ObjectList = new List<ProgrammableObject>();
    public ProgrammableObject curObject = null;
    public float flameRate = 120;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // public static Camera camera;
    public void RegisterObject(ProgrammableObject p)
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

    public ProgrammableObject GetObject(int num)
    {
        curObject = p_ObjectList[num];
        return curObject;
    }
}
