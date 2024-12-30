// using System.Collections;
// using System.Collections.Generic;
// using UBlockly;
// using UBlockly.UGUI;
// using UnityEngine;

// public class RegisterBlocks : MonoBehaviour
// {
//     private int index;

//     public int Index
//     {
//         get
//         {
//             return index;
//         }
//         set
//         {
//             index = value;
//         }
//     }

//     public void Register()
//     {
//         // ワークスペースを取得
//         Workspace workspace = BlocklyUI.WorkspaceView.Workspace;

//         // workspaceから全てのブロックを取得
//         List<Block> blocks = workspace.GetTopBlocks(true).FindAll(block => !ProcedureDB.IsDefinition(block));

//         GameManager.instance.blockList.Add(blocks);

//         foreach (List<Block> blockList in GameManager.instance.blockList)
//         {
//             Debug.Log("BlockList " + GameManager.instance.blockList.IndexOf(blockList));
//             foreach (Block block in blockList)
//             {
//                 Debug.Log(block.Type);
//             }
//         }

//         GameManager.instance.SaveXml();
//     }

//     public void DeleteWindow()
//     {
//         BlocklyUI.UICanvas.gameObject.SetActive(false);
//     }
// }
