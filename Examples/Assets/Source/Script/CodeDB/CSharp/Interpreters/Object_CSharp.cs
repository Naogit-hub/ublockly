using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace UBlockly
{
    // This next block of code is for one block, if the 
    //category has multiple blocks repeat this for each one

    /* オブジェクトを移動させる */
    [CodeInterpreter(BlockType = "object_move")]
    public class Object_Move_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            
            yield return GameManager.curObject.MoveForword();
        }
    }

    /* オブジェクトを取得する */
    [CodeInterpreter(BlockType = "object_get")]
    public class Object_Get_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            // throw new System.NotImplementedException();
            Debug.Log("get: " + GameManager.GetObject(0).name);
            yield return GameManager.GetObject(0);
        }
    }

    /* オブジェクトを回転させる */
    [CodeInterpreter(BlockType = "object_rotate")]
    public class Object_Rotate_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            //一旦、x軸で30度回転させる.
            // GameManager.GetObject(0).ChangeRotate(2, 30);
            yield return GameManager.curObject.ChangeRotate(2, 30f);
            // throw new System.NotImplementedException();
        }
    }
    /* オブジェクトの色を変える */
    [CodeInterpreter(BlockType = "object_color")]
    public class Object_Color_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            throw new System.NotImplementedException();
        }
    }
    /* オブジェクトの大きさを変える */
    [CodeInterpreter(BlockType = "object_scale")]
    public class Object_Scale_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            // 2倍する。
            yield return GameManager.curObject.ChangeScale(2);
            // throw new System.NotImplementedException();
            
        }
    }
    /* オブジェクトを探知する(trigger) */
    [CodeInterpreter(BlockType = "object_search")]
    public class Object_Search_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            throw new System.NotImplementedException();
        }
    }
}