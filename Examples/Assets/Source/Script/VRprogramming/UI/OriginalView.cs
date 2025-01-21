using System.Collections;
using System.Collections.Generic;
using UBlockly;
using UBlockly.UGUI;
using UnityEngine;
using UnityEngine.UI;

public class OriginalView : MonoBehaviour
{
    private int index;
    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    [SerializeField] protected Button m_RegisterBtn;
    [SerializeField] protected Button m_DeleteWindowBtn;
    [SerializeField] protected Button m_ChangePositionBtn;
    [SerializeField] protected Button m_CancelBtn;
    [SerializeField] protected Button m_AllRunBtn;
    [SerializeField] protected Button m_AllCancelBtn;

    /// <summary>
    /// blockを登録するボタン
    /// </summary>
    private void Awake()
    {
        m_RegisterBtn.onClick.AddListener(() =>
        {
            // Register();
            RegisterObjectId();
        });

        m_DeleteWindowBtn.onClick.AddListener(() =>
        {
            DeleteWindow();
        });

        m_ChangePositionBtn.onClick.AddListener(() =>
        {
            ChangePosition();
        });

        m_CancelBtn.onClick.AddListener(() =>
        {
            Cancel();
        });

        m_AllRunBtn.onClick.AddListener(() =>
        {
            AllRun();
            BlocklyUI.UICanvas.gameObject.SetActive(false);
        });

        m_AllCancelBtn.onClick.AddListener(() =>
        {
            AllCancel();
        });
    }

    /// <summary>
    /// ブロックを登録する
    /// </summary>
    // public void Register()
    // {
    //     // ワークスペースを取得
    //     Workspace workspace = BlocklyUI.WorkspaceView.Workspace;

    //     // workspaceから全てのブロックを取得
    //     List<Block> blocks = workspace.GetTopBlocks(true).FindAll(block => !ProcedureDB.IsDefinition(block));

    //     GameManager.instance.blockList.Add(blocks);

    //     foreach (List<Block> blockList in GameManager.instance.blockList)
    //     {
    //         Debug.Log("BlockList " + GameManager.instance.blockList.IndexOf(blockList));
    //         foreach (Block block in blockList)
    //         {
    //             Debug.Log(block.Type);
    //         }
    //     }

    //     GameManager.instance.SaveXml();
    // }

    /// <summary>
    /// オブジェクトのIDを登録する
    /// </summary>
    public void RegisterObjectId()
    {
        if (!GameManager.instance.curObject.IsReadOnly)
        {
            GameManager.instance.SaveXml();
            GameManager.instance.curObject.DefaultXML = "";
        }

        GameManager.instance.p_ObjectDict.Add(GameManager.instance.curUniqueID, GameManager.instance.curObject);

        // foreach (KeyValuePair<int, ProgrammableObject> p_Object in GameManager.instance.p_ObjectDict)
        // {
        //     Debug.Log("Key: " + p_Object.Key + " Value: " + p_Object.Value);
        // }
    }

    /// <summary>
    /// オブジェクトIDを辞書から削除する
    /// </summary>
    public void Cancel()
    {
        if (GameManager.instance.p_ObjectDict.ContainsKey(GameManager.instance.curUniqueID))
        {
            GameManager.instance.p_ObjectDict.Remove(GameManager.instance.curUniqueID);
            Debug.Log("削除しました");
        }
    }

    /// <summary>
    /// すべてのIDを辞書から削除する
    /// </summary>
    public void AllCancel()
    {
        GameManager.instance.p_ObjectDict.Clear();
    }

    /// <summary>
    /// ウィンドウを閉じる
    /// </summary>
    public void DeleteWindow()
    {
        BlocklyUI.UICanvas.gameObject.SetActive(false);
        // GameManager.instance.curObject.directionCanvas.gameObject.SetActive(false);
        if (!GameManager.instance.curObject.IsReadOnly)
        {
            GameManager.instance.SaveXml();
            GameManager.instance.curObject.DefaultXML = "";
        }
    }

    public void AllRun()
    {
        GameManager.instance.Run();
    }

    public void ChangePosition()
    {
        Vector3 newPos = GameManager.instance.GetUIPos();

        Vector3 newRotate = BlocklyUI.UICanvas.transform.rotation.eulerAngles;
        newRotate.y = GameManager.instance.uiPos.transform.rotation.eulerAngles.y;

        BlocklyUI.UICanvas.gameObject.SetActive(true);
        BlocklyUI.UICanvas.transform.position = newPos;
        BlocklyUI.UICanvas.transform.rotation = Quaternion.Euler(newRotate);
    }
}
