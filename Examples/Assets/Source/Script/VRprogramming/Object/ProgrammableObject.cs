using System.Collections;
using System.Collections.Generic;
using UBlockly.UGUI;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProgrammableObject : MonoBehaviour, IProgrammable
{
    [SerializeField]
    private Menu menu;

    public Menu Menu
    {
        get { return menu; }
    }

    // public Canvas directionCanvas; // 方向を表示するキャンバス
    private Coroutine hoverCoroutine; // ホバーを監視するコルーチン

    private Vector3 initialPosition; // 初期位置
    private Quaternion initialRotation; // 初期回転
    private Vector3 initialScale; // 初期スケール

    void Start()
    {
        if (menu != null)
        {
            menu.gameObject.SetActive(false);
        }

        // if (directionCanvas != null)
        // {
        //     directionCanvas.gameObject.SetActive(false);
        // }
        // rb = this.GetComponent<Rigidbody>();

        // 初期状態を保存
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
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

        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * amount;
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

    /// <summary>
    /// オブジェクトのスケールを変更する
    /// </summary>
    /// <param name="num">何倍するか</param>
    /// <returns></returns>
    public virtual IEnumerator ChangeScale(float num)
    {
        // Vector3 curScale = rb.transform.localScale;
        // rb.transform.localScale = new Vector3(curScale.x * num, curScale.y * num, curScale.z * num);
        // yield return null;

        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = 1f;

        Vector3 start = transform.localScale;
        Vector3 end = start * num;
        // end.x *= num;
        // end.y *= num;
        // end.z *= num;

        Debug.Log("拡大中");
        while (elapsedTime < duration)
        {
            // 線形補間で現在の大きさを計算
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
    public virtual IEnumerator ChangeRotate(float amount, int axis = 2)
    {
        // ワールド座標を基準に、回転を取得
        Vector3 start = transform.eulerAngles;
        Vector3 end = start;

        float elapsedTime = 0f; // 経過時間のカウンター
        float duration = amount / 90f; //実行時間

        // 一旦y軸中心固定
        // int axis = 2;
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

        Debug.Log("回転中");
        while (elapsedTime < duration)
        {
            // 線形補間で現在の位置を計算
            transform.eulerAngles = Vector3.Lerp(start, end, elapsedTime / duration);

            // float t = elapsedTime / duration;
            // t = Mathf.SmoothStep(0f, 1f, t);
            // transform.eulerAngles = Vector3.Lerp(start, end, t);

            // 時間を更新
            elapsedTime += Time.deltaTime;

            // フレーム終了まで待機
            yield return null;
        }

        transform.eulerAngles = end; // 回転させる。
        Debug.Log("正面方向: " + transform.forward);
        yield return null;
    }

    // XR Interaction Toolkitのホバー開始イベント
    public void HoverEnter()
    {
        if (hoverCoroutine == null)
        {
            hoverCoroutine = StartCoroutine(HoverTimerCoroutine());

            if (GameManager.instance.progressBar != null)
            {
                GameManager.instance.progressBar.gameObject.SetActive(true); // 進捗バーを表示
                GameManager.instance.progressBar.value = 0; // 初期値にリセット
            }
        }
    }

    // XR Interaction Toolkitのホバー終了イベント
    public void HoverExit()
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null; // コルーチンをリセット

            if (GameManager.instance.progressBar != null)
            {
                GameManager.instance.progressBar.gameObject.SetActive(false); // 進捗バーを非表示
            }
        }
    }

    public void SelectEnter()
    {
        if (hoverCoroutine != null)
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null; // コルーチンをリセット

            if (GameManager.instance.progressBar != null)
            {
                GameManager.instance.progressBar.gameObject.SetActive(false); // 進捗バーを非表示
            }
        }
    }
    private IEnumerator HoverTimerCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < GameManager.SHOW_MENU_TIME)
        {
            elapsedTime += Time.deltaTime;

            if (GameManager.instance.progressBar != null)
            {
                GameManager.instance.progressBar.value = elapsedTime; // 進捗バーの値を更新
            }

            yield return null;
        }

        ToggleShowMenu();
    }
    public void ToggleShowMenu()
    {
        if (menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(false);
            GameManager.instance.progressBar.gameObject.SetActive(false); // 進捗バーを非表示
            return;
        }

        menu.gameObject.SetActive(true);
        UnityEngine.Vector3 newRotate = menu.transform.rotation.eulerAngles;
        newRotate.y = GameManager.instance.uiPos.transform.rotation.eulerAngles.y;
        menu.gameObject.transform.rotation = UnityEngine.Quaternion.Euler(newRotate);
        // menu.gameObject.transform.position = GameManager.instance.GetUIPos();

        menu.SetId(this.GetInstanceID());
        menu.SetPObject(this);

        if (GameManager.instance.progressBar != null)
        {
            GameManager.instance.progressBar.gameObject.SetActive(false); // 進捗バーを非表示
        }
    }

    public void Reset()
    {
        // 位置、回転、スケールを初期値に戻す
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;

        Debug.Log(gameObject.name + "を元の位置に戻しました。");
    }
}
