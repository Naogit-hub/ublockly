using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockController
{
    // 前に動く
    public void Move();

    // 止まる
    public void Stop();
    
    // 回転する
    public void Rotate();

    // スケールを変更する
    public void ScaleChange();

    // イベント発生
    public void Event();
}