using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : ProgrammableObject
{
    /// <summary>
    /// タスクシーンにおける1マスのサイズ
    /// </summary>
    public const float SQUARE_SIZE = 1f;
    private float speed = 1f;
    protected int taskNum;

    private Rigidbody rb;
    public void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
        // Debug.Log("name: " + this.gameObject.name);
        // Debug.Log("id: " + this.gameObject.GetInstanceID());
        // Debug.Log("Task Start");
    }

    // public override IEnumerator MoveForword(float amount)
    // {
    //     if (!CheckAbleToMove())
    //     {
    //         Debug.Log("壁があるため移動できません");
    //         yield break;
    //     }

    //     float elapsedTime = 0f; // 経過時間のカウンター
    //     float duration = amount * 0.7f; //実行時間

    //     Vector3 start = transform.position;
    //     Vector3 end = start + transform.forward * amount * SQUARE_SIZE;
    //     // end += transform.forward * amount;

    //     Debug.Log("移動中");
    //     while (elapsedTime < duration)
    //     {
    //         // 線形補間で現在の位置を計算
    //         transform.position = Vector3.Lerp(start, end, elapsedTime / duration);

    //         // 時間を更新
    //         elapsedTime += Time.deltaTime;

    //         // フレーム終了まで待機
    //         yield return null;
    //     }

    //     // 最終的な位置を確実にセット
    //     transform.position = end;
    // }

    public override IEnumerator MoveForword(float amount)
    {
        rb.isKinematic = false;
        if (!CheckAbleToMove())
        {
            Debug.Log("壁があるため移動できません");
            yield break;
        }
        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount; // かかる移動時間

        Vector3 direction = transform.forward.normalized; // 前方方向
        Vector3 velocity = direction * 1f; // 移動速度を計算

        rb.velocity = velocity; // Rigidbodyに速度を設定

        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * amount * SQUARE_SIZE;
        // end += transform.forward * amount;

        Debug.Log("移動中");
        while (elapsedTime < duration)
        {
            // 時間を更新
            elapsedTime += Time.deltaTime;

            // フレーム終了まで待機
            yield return null;
        }

        rb.velocity = Vector3.zero; // 移動終了時に速度を0に
        rb.isKinematic = true;
    }
    public bool CheckAbleToMove()
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
