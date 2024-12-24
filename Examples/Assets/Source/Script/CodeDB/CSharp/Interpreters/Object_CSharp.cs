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
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0));
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            yield return GameManager.instance.curObject.MoveForword(arg0.NumberValue.Value);
        }
    }

    /* オブジェクトを回転させる */
    [CodeInterpreter(BlockType = "object_rotate")]
    public class Object_Rotate_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0));
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            yield return GameManager.instance.curObject.ChangeRotate(arg0.NumberValue.Value);
        }
    }

    /* オブジェクトを取得する */
    [CodeInterpreter(BlockType = "object_get")]
    public class Object_Get_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            yield return null;
        }
        // protected override DataStruct Execute(Block block)
        // {
        //     // return CSharp.VariableDatas.GetData(varName);
        // }

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
            yield return GameManager.instance.curObject.ChangeScale(2);
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