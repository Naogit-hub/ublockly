using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Microsoft.Unity.VisualStudio.Editor;
using UBlockly;
using UBlockly.UGUI;
using UnityEngine;
using UnityEngine.Networking;

public class Menu : MonoBehaviour
{
    private int uniqueId;

    // 操作対象のオブジェクト
    private ProgrammableObject p_object;

    public void SetId(int id)
    {
        uniqueId = id;
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
        // Vector3 thisPos = this.transform.position;
        UnityEngine.Vector3 newPos = GameManager.instance.GetUIPos();

        UnityEngine.Vector3 newRotate = BlocklyUI.UICanvas.transform.rotation.eulerAngles;
        newRotate.y = GameManager.instance.uiPos.transform.rotation.eulerAngles.y;

        // directionCanvas.gameObject.SetActive(true);

        // if(GameManager.instance.curObject.directionCanvas != null)
        // {
        //     GameManager.instance.curObject.directionCanvas.gameObject.SetActive(false);
        // }
        // p_object.directionCanvas.gameObject.SetActive(true);
        BlocklyUI.UICanvas.gameObject.SetActive(true);
        BlocklyUI.UICanvas.transform.position = newPos;
        BlocklyUI.UICanvas.transform.rotation = UnityEngine.Quaternion.Euler(newRotate);

        GameManager.instance.curUniqueID = uniqueId;
        // Debug.Log("object" + uniqueId);
        GameManager.instance.curObject = p_object;
        GameManager.instance.targetField.SetTargetObject(p_object);

        // Debug.Log("curObject: " + GameManager.instance.curObject);

        if (p_object.DefaultXML != "")
        {
            // Debug.Log("デフォルトXMLが設定されている");
            GameManager.instance.LoadXml(p_object.DefaultXML);
        }
        else
        {
            // Debug.Log("デフォルトXMLが設定されていない");
            GameManager.instance.LoadXml("object" + uniqueId);
        }

        // BlocklyUI.NewWorkspace();
        // throw new System.NotImplementedException();

        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// オブジェクトの状態をもとに戻す
    /// </summary>
    public void ResetTransform()
    {
        p_object.ResetObject();
    }

    public void CopyXML()
    {
        CD cd = Instantiate(GameManager.instance.cdPrefab);

        if (p_object.DefaultXML != "")
        {
            cd.Xml = p_object.DefaultXML;
        }
        else
        {
            cd.Xml = "object" + uniqueId;
        }

        // cd.ID = uniqueId;
        cd.transform.position = this.transform.position;
        this.gameObject.SetActive(false);

        Debug.Log("copy XML: " + cd.Xml);
    }

    public void Clone()
    {
        if (!p_object.IsReadOnly) {
            ProgrammableObject cloneObject = Instantiate(this.p_object);
            cloneObject.DefaultXML = "object" + uniqueId;
        }
    }

    public void ChangeGravity()
    {
        bool tmp = p_object.rb.useGravity;
        p_object.rb.useGravity = !tmp;
    }
}
