using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : ProgrammableObject
{
    /// <summary>
    /// タスクシーンにおける1マスのサイズ
    /// </summary>
    public const float SQUARE_SIZE = 1f;
    protected int taskNum;

    // public void Start()
    // {
    //     // Debug.Log("name: " + this.gameObject.name);
    //     // Debug.Log("id: " + this.gameObject.GetInstanceID());
    //     // Debug.Log("Task Start");
    // }

    public override IEnumerator MoveForword(float amount)
    {
        if (!CheckNextSquare())
        {
            Debug.Log("壁があるため移動できません");
            yield break;
        }

        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount * 0.7f; //実行時間

        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * amount * SQUARE_SIZE;
        // end += transform.forward * amount;

        Debug.Log("移動中");
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
    public bool CheckNextSquare()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, SQUARE_SIZE))
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}
