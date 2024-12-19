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
    /// <param name="num">オブジェクトの移動量</param>
    /// <returns></returns>
    public virtual IEnumerator MoveForword(int num)
    {
        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = 1f;

        Vector3 start = rb.transform.position;
        Vector3 end = rb.transform.position;
        end.x += 1f;

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
    /// <param name="axis">回転の軸</param>
    /// <param name="num">回転量</param>
    /// <returns></returns>
    public virtual IEnumerator ChangeRotate(int axis, float num)
    {
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = rb.transform.eulerAngles;
        Debug.Log("Angle: " + worldAngle);

        switch (axis)
        {
            case 1: // x
                worldAngle.x = worldAngle.x + num;
                break;
            case 2: // y
                worldAngle.z = worldAngle.y + num;
                break;
            case 3: // z
                worldAngle.z = worldAngle.z + num;
                break;
            default:
                break;
        }
        Debug.Log("Angle: " + worldAngle);
        rb.transform.eulerAngles = worldAngle; // 回転させる。
        yield return null;
    }

    public void RegisterThis()
    {
        GameManager.RegisterObject(this);
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
