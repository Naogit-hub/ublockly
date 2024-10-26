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
            yield return null;
            // yield return MazeController.Instance.DoMoveForward();
        }
    }
}