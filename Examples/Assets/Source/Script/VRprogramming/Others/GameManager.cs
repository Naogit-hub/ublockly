using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UBlockly;
using UBlockly.UGUI;
using UnityEngine.Networking;
using System;
using System.Numerics;
using Unity.Mathematics;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public ProgrammableObject curObject = null;
    public Slider progressBar;
    public GameObject uiPos;
    // public List<List<Block>> blockList = new List<List<Block>>();

    /// <summary>
    /// 登録されたオブジェクトのIDリスト
    /// </summary>
    // public List<int> idList = new List<int>();
    // public List<ProgrammableObject> p_ObjectList = new List<ProgrammableObject>();

    public Dictionary<int, ProgrammableObject> p_ObjectDict = new Dictionary<int, ProgrammableObject>();
    public List<Workspace> workspaceList = new List<Workspace>();
    public TargetField targetField;

    /// <summary>
    /// 実行中のコマンド番号
    /// </summary>
    private int cmdNum = 0;

    public int CmdNum
    {
        get
        {
            return cmdNum;
        }
        set
        {
            cmdNum = value;
        }
    }

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
    // public void RegisterObject(ProgrammableObject p)
    // {
    //     p_ObjectList.Add(p);
    //     curObject = p;
    // }

    // public ProgrammableObject GetObject(int num)
    // {
    //     curObject = p_ObjectList[num];
    //     return curObject;
    // }

    // XMLファイルのセーブとロード
    private string mSavePath;
    public int curUniqeID = 0;
    public string GetSavePath()
    {
        if (string.IsNullOrEmpty(mSavePath))
        {
            mSavePath = System.IO.Path.Combine(Application.persistentDataPath, "XmlSave");
            if (!System.IO.Directory.Exists(mSavePath))
                System.IO.Directory.CreateDirectory(mSavePath);
        }
        return mSavePath;
    }

    /// <summary>
    /// Save the workspace to xml
    /// </summary>
    public void SaveXml()
    {
        var dom = UBlockly.Xml.WorkspaceToDom(BlocklyUI.WorkspaceView.Workspace);
        string text = UBlockly.Xml.DomToText(dom);
        string path = GetSavePath();

        path = System.IO.Path.Combine(path, "object" + curUniqeID + ".xml");

        System.IO.File.WriteAllText(path, text);
    }

    /// <summary>
    /// Load the workspace from xml
    /// </summary>
    /// <param name="fileName"></param>
    public void LoadXml(string fileName, Workspace workspace = null)
    {
        StartCoroutine(AsyncLoadXml(fileName, workspace));
    }

    /// <summary>
    /// Load the workspace from xml Coroutine
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    IEnumerator AsyncLoadXml(string fileName, Workspace workspace = null)
    {
        BlocklyUI.WorkspaceView.CleanViews();

        string path = System.IO.Path.Combine(GetSavePath(), fileName + ".xml");
        string inputXml;
        if (path.Contains("://"))
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(path))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    throw new Exception(webRequest.error + ": " + path);
                }
                inputXml = webRequest.downloadHandler.text;
            }
        }
        else if (System.IO.File.Exists(path))
        {
            Debug.Log("File found");
            inputXml = System.IO.File.ReadAllText(path);
        }
        else
        {
            Debug.Log("File not found");
            yield break; // File not found
        }

        if (workspace == null)
        {
            workspace = BlocklyUI.WorkspaceView.Workspace;
        }

        var dom = UBlockly.Xml.TextToDom(inputXml);
        UBlockly.Xml.DomToWorkspace(dom, workspace);
        BlocklyUI.WorkspaceView.BuildViews();
    }

    /// <summary>
    /// 特定のXMLファイルを削除
    /// </summary>
    /// <param name="fileName"></param>
    public void DeleteXml(string fileName)
    {
        string path = System.IO.Path.Combine(GetSavePath(), fileName + ".xml");
        if (System.IO.File.Exists(path))
        {
            Debug.Log("Delete file found");
            System.IO.File.Delete(path);
        }
    }

    /// <summary>
    /// object-*.xmlを全て削除 (TaskオブジェクトのXML)
    /// </summary>
    public void DeleteAllXml()
    {
        string path = GetSavePath();
        if (System.IO.Directory.Exists(path))
        {
            string[] files = System.IO.Directory.GetFiles(path, "object-*.xml");
            foreach (string file in files)
            {
                System.IO.File.Delete(file);
            }
        }
    }

    public void Run()
    {
        if (CSharp.Runner.CurStatus == Runner.Status.Stop)
        {
            // CSharp.Runner.ListRun(BlocklyUI.WorkspaceView.Workspace);
            CSharp.Runner.ListRunId();
        }
        else
        {
            CSharp.Runner.Resume();
        }
    }

    public UnityEngine.Vector3 GetUIPos()
    {
        UnityEngine.Vector3 newPos = uiPos.transform.position;
        newPos.y = Math.Max(newPos.y, 1f);

        return newPos;
    }
}
