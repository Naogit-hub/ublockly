using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public List<ProgrammableObject> p_ObjectList = new List<ProgrammableObject>();
    public ProgrammableObject curObject = null;
    public Slider progressBar;

    public const float SHOW_MENU_TIME = 1.5f;
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

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(false); // 初期状態で進捗バーを非表示にする
            progressBar.maxValue = SHOW_MENU_TIME; // 進捗バーの最大値を設定
            progressBar.value = 0; // 初期値を0にする
        }
    }
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
