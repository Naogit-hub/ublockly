using UnityEngine;

public class ObjectController : MonoBehaviour, IBlockController
{
    // 前に動く
    public virtual void Move(){}

    // 止まる
    public virtual void Stop(){}
    
    // 回転する
    public virtual void Rotate(){}

    // スケールを変更する
    public virtual void ScaleChange(){}

    // イベント発生
    public virtual void Event(){}
}