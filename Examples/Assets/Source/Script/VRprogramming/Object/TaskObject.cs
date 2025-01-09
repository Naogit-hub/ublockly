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
    public void Start()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    /// <summary>
    /// 物理的な挙動の移動
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public override IEnumerator MoveForword(float amount)
    {
        rb.isKinematic = false;
        if (!CheckAbleToMove())
        {
            Debug.Log("壁があるため移動できません");
            yield return new WaitForSeconds (1.0f);
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
    public override bool CheckAbleToMove()
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
