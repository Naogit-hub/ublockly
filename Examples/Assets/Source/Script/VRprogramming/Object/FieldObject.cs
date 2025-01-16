using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObject : ProgrammableObject
{
    public override IEnumerator MoveForword(float amount)
    {
        rb.isKinematic = false;
        rb.useGravity = false;
        if (!CheckAbleToMove())
        {
            Debug.Log("壁があるため移動できません");
            yield break;
        }
        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount; // かかる移動時間

        Vector3 direction = transform.forward.normalized; // 前方方向
        Vector3 velocity = direction * 3f; // 移動速度を計算

        rb.velocity = velocity; // Rigidbodyに速度を設定

        Vector3 start = transform.position;
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

    // private void OnCollisionStay(Collision other) {

    // }
}
