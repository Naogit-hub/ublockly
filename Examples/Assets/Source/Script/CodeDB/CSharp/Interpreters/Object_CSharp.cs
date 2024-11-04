using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UBlockly
{   
    // This next block of code is for one block, if the 
    //category has multiple blocks repeat this for each one
    [CodeInterpreter(BlockType = "object_move")]
    public class Object_Move_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            // if(BlocklyCanvasController.instance.p_object is null)
            // {
            //     Debug.Log("NULL");
            //     yield return null;
            // }
            Tmp tmp = GameObject.Find("TMP").GetComponent<Tmp>();
            yield return tmp.p.MoveForword();
            // yield return MazeController.Instance.DoMoveForward();
        }
    }
}