using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : ProgrammableObject
{
    /// <summary>
    /// タスクシーンにおける1マスのサイズ
    /// </summary>
    public const float SQUARE_SIZE = 10f;
    protected int taskNum;

    public override IEnumerator MoveForword(int num)
    {
        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = 1f * num;  

        Vector3 start = rb.transform.position;
        Vector3 end = rb.transform.position;
        end.x += num * SQUARE_SIZE;

        while (elapsedTime < duration)
        {
            // 線形補間で現在の位置を計算
            transform.position = Vector3.Lerp(start, end, elapsedTime / duration);

            // 時間を更新
            elapsedTime += Time.deltaTime;

            // フレーム終了まで待機
            yield return null;
        }

        // 最終的な位置を確実にセット
        transform.position = end;
    }
}
