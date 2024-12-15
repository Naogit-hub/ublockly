using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammableObject : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void ShowWorkSpace()
    {

    }

    // public IEnumerator MoveForword()
    // {
    //     float second = 0;

    //     // rb.transform.Translate(0.1f, 0, 0);

    //     // while (second < Time.deltaTime * GameManager.flameRate)
    //     // {
    //     //     rb.transform.Translate(0.001f, 0, 0);
    //     //     second += Time.deltaTime;
    //     // }

    //     Vector3 curPos = rb.transform.position;
    //     curPos.x += 1f;
    //     Vector3.Lerp(rb.transform.position, curPos, );

    //     yield return null;
    // }

    public IEnumerator MoveForword()
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

    /* オブジェクトのスケールを全体的にnum倍する */
    public IEnumerator ChangeScale(int num)
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

    public IEnumerator ChangeRotate(int axis, float num)
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
}
