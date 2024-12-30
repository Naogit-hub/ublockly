using System;
using System.Collections;
using System.Collections.Generic;
using UBlockly.UGUI;
using UnityEngine;
using UnityEngine.Networking;

public class Menu : MonoBehaviour
{
    private int uniqeID;

    // 操作対象のオブジェクト
    private ProgrammableObject p_object;

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

        GameManager.instance.curUniqeID = uniqeID;
        Debug.Log("object" + uniqeID);
        GameManager.instance.curObject = p_object;
        Debug.Log("curObject: " + GameManager.instance.curObject);
        
        GameManager.instance.LoadXml("object" + uniqeID);
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
}
