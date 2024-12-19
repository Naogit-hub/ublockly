using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgrammableObject : MonoBehaviour, IProgrammable
{
    protected Rigidbody rb;

    protected Transform tr;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tr = rb.transform;
    }

    /// <summary>
    /// オブジェクトを前方に動かす
    /// </summary>
    /// <param name="amount">オブジェクトの移動量</param>
    /// <returns></returns>
    public virtual IEnumerator MoveForword(float amount)
    {
        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount * 0.7f; //実行時間

        Vector3 start = rb.transform.position;
        Vector3 end = start + transform.forward * amount;
        // end += transform.forward * amount;

        Debug.Log("amount: " + amount);
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

    /// <summary>
    /// オブジェクトのスケールを変更する
    /// </summary>
    /// <param name="num">何倍するか</param>
    /// <returns></returns>
    public virtual IEnumerator ChangeScale(int num)
    {
        // Vector3 curScale = rb.transform.localScale;
        // rb.transform.localScale = new Vector3(curScale.x * num, curScale.y * num, curScale.z * num);
        // yield return null;

        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = 1f;

        Vector3 start = rb.transform.localScale;
        Vector3 end = start;
        end.x *= 2;
        end.y *= 2;
        end.z *= 2;

        while (elapsedTime < duration)
        {
            // 線形補間で現在の位置を計算
            transform.localScale = Vector3.Lerp(start, end, elapsedTime / duration);

            // 時間を更新
            elapsedTime += Time.deltaTime;

            // フレーム終了まで待機
            yield return null;
        }

        // 最終的な位置を確実にセット
        transform.localScale = end;
    }

    /// <summary>
    /// オブジェクトを回転させる
    /// </summary>
    /// <param name="amount">回転量</param>
    /// <returns></returns>
    public virtual IEnumerator ChangeRotate(float amount)
    {
        // ワールド座標を基準に、回転を取得
        Vector3 start = rb.transform.eulerAngles;
        Vector3 end = start;

        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount / 90f; //実行時間

        // 一旦y軸中心固定
        int axis = 2;
        switch (axis)
        {
            case 1: // x
                end.x += amount;
                break;
            case 2: // y
                end.y += amount;
                break;
            case 3: // z
                end.z += amount;
                break;
            default:
                break;
        }


        while (elapsedTime < duration)
        {
            // 線形補間で現在の位置を計算
            transform.eulerAngles = Vector3.Lerp(start, end, elapsedTime / duration);

            // 時間を更新
            elapsedTime += Time.deltaTime;

            // フレーム終了まで待機
            yield return null;
        }

        transform.eulerAngles = end; // 回転させる。
        yield return null;
    }

    public void RegisterThis()
    {
        GameManager.instance.RegisterObject(this);
    }

    public void ShowWorkspace()
    {
        throw new System.NotImplementedException();
    }

    public void DeleteWorkspace()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        //元の位置・大きさに戻る
        rb.transform.position = tr.position;
        rb.transform.localScale = tr.localScale;
        rb.transform.eulerAngles = tr.eulerAngles;
    }

}
