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
        protected override IEnumerator Execute(Block block, int id)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0), id);
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            Debug.Log("move id: " + id);
            if (GameManager.instance.p_ObjectDict.TryGetValue(id, out ProgrammableObject p_Object))
            {
                Debug.Log("操作対象のオブジェクト: " + GameManager.instance.p_ObjectDict[id]);
                yield return p_Object.MoveForword(arg0.NumberValue.Value);
            }
            else
            {
                yield return GameManager.instance.curObject.MoveForword(arg0.NumberValue.Value);
            }
        }
    }

    /* オブジェクトを回転させる */
    [CodeInterpreter(BlockType = "object_rotate")]
    public class Object_Rotate_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block, int id)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0), id);
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            Debug.Log("rotate id: " + id);

            if (GameManager.instance.p_ObjectDict.TryGetValue(id, out ProgrammableObject p_Object))
            {
                Debug.Log("操作対象のオブジェクト: " + GameManager.instance.p_ObjectDict[id]);
                yield return p_Object.ChangeRotate(arg0.NumberValue.Value);
            }
            else
            {
                yield return GameManager.instance.curObject.ChangeRotate(arg0.NumberValue.Value);
            }
        }
    }

    /* オブジェクトの色を変える */
    [CodeInterpreter(BlockType = "object_color")]
    public class Object_Color_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block, int id)
        {
            throw new System.NotImplementedException();
        }
    }
    /* オブジェクトの大きさを変える */
    [CodeInterpreter(BlockType = "object_scale")]
    public class Object_Scale_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block, int id)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0), id);
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            Debug.Log("move id: " + id);
            if (GameManager.instance.p_ObjectDict.TryGetValue(id, out ProgrammableObject p_Object))
            {
                Debug.Log("操作対象のオブジェクト: " + GameManager.instance.p_ObjectDict[id]);
                yield return p_Object.ChangeScale(arg0.NumberValue.Value);
            }
            else
            {
                yield return GameManager.instance.curObject.ChangeScale(arg0.NumberValue.Value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [CodeInterpreter(BlockType = "object_target_check")]
    public class Object_Search_cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block, int id)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "amount", new DataStruct(0), id);
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            DataStruct returnData = new DataStruct(false);

            string op = block.GetFieldValue("object_type");

            if (GameManager.instance.p_ObjectDict.TryGetValue(id, out ProgrammableObject p_Object))
            {
                Debug.Log("操作対象のオブジェクト: " + GameManager.instance.p_ObjectDict[id]);
                returnData.BooleanValue = p_Object.CheckNextTarget(arg0.NumberValue.Value, op);
            }
            else
            {
                returnData.BooleanValue = GameManager.instance.curObject.CheckNextTarget(arg0.NumberValue.Value, op);
            }
            ReturnData(returnData);
        }
    }
}