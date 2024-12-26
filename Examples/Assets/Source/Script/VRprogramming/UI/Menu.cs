using System;
using System.Collections;
using System.Collections.Generic;
using UBlockly.UGUI;
using UnityEngine;
using UnityEngine.Networking;

public class Menu : MonoBehaviour
{
    private int uniqeID;
    private ProgrammableObject p_object;

    [SerializeField]
    private XmlView xmlView;

    public void SetId(int id)
    {
        uniqeID = id;
        Debug.Log("id: " + uniqeID);
    }

    public void SetPObject(ProgrammableObject programmableObject)
    {
        p_object = programmableObject;
    }

    /// <summary>
    /// 関連づいたワークスペースを表示させる。
    /// </summary>
    public void ShowWorkspace()
    {
        Vector3 thisPos = this.transform.position;

        BlocklyUI.UICanvas.gameObject.SetActive(true);
        BlocklyUI.UICanvas.transform.position = thisPos;


        LoadXml("object" + uniqeID);
        // BlocklyUI.NewWorkspace();
        // throw new System.NotImplementedException();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 関連づいたワークスペースを非表示にする。
    /// </summary>
    public void DeleteWorkspace() { }

    /// <summary>
    /// オブジェクトの状態をもとに戻す
    /// </summary>
    public void ResetTransform()
    {
        p_object.Reset();
    }

    private string mSavePath;

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

        path = System.IO.Path.Combine(path, "object" + uniqeID + ".xml");

        System.IO.File.WriteAllText(path, text);
    }

    /// <summary>
    /// Load the workspace from xml
    /// </summary>
    /// <param name="fileName"></param>
    public void LoadXml(string fileName)
    {
        StartCoroutine(AsyncLoadXml(fileName));
    }

    /// <summary>
    /// Load the workspace from xml Coroutine
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    IEnumerator AsyncLoadXml(string fileName)
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

        var dom = UBlockly.Xml.TextToDom(inputXml);
        UBlockly.Xml.DomToWorkspace(dom, BlocklyUI.WorkspaceView.Workspace);
        BlocklyUI.WorkspaceView.BuildViews();
    }
}
