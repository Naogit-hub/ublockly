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
    }

    /// <summary>
    /// ブロックを登録する
    /// </summary>
    public void Register()
    {
        // ワークスペースを取得
        Workspace workspace = BlocklyUI.WorkspaceView.Workspace;

        // workspaceから全てのブロックを取得
        List<Block> blocks = workspace.GetTopBlocks(true).FindAll(block => !ProcedureDB.IsDefinition(block));

        GameManager.instance.blockList.Add(blocks);

        foreach (List<Block> blockList in GameManager.instance.blockList)
        {
            Debug.Log("BlockList " + GameManager.instance.blockList.IndexOf(blockList));
            foreach (Block block in blockList)
            {
                Debug.Log(block.Type);
            }
        }

        GameManager.instance.SaveXml();
    }

    public void RegisterObjectId()
    {
        GameManager.instance.SaveXml();
        GameManager.instance.idList.Add(GameManager.instance.curUniqeID);
        GameManager.instance.p_ObjectList.Add(GameManager.instance.curObject);

        foreach (int id in GameManager.instance.idList)
        {
            Debug.Log("ID: " + id);
        }

        foreach (ProgrammableObject p_Object in GameManager.instance.p_ObjectList)
        {
            Debug.Log("p_Object: " + p_Object);
        }
    }
    /// <summary>
    /// ウィンドウを閉じる
    /// </summary>
    public void DeleteWindow()
    {
        BlocklyUI.UICanvas.gameObject.SetActive(false);
        GameManager.instance.SaveXml();
    }
}
