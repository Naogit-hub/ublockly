using System.Collections;
using System.Collections.Generic;
using UBlockly.UGUI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private int uniqeID;
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

        this.gameObject.SetActive(false);
        BlocklyUI.UICanvas.gameObject.SetActive(true);
        BlocklyUI.UICanvas.transform.position = thisPos;
        // BlocklyUI.NewWorkspace();
        // throw new System.NotImplementedException();
    }

    /// <summary>
    /// 関連づいたワークスペースを非表示にする。
    /// </summary>
    public void DeleteWorkspace(){}

    public void ResetTransform()
    {
        p_object.Reset();
    }
}
