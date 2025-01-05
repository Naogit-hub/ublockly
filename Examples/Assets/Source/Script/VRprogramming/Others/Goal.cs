using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private float stayTime = 0f;
    // private bool hasLogged = false;
    private Task task;
    private bool isGoal = false;

    public bool IsGoal { get { return isGoal; } }

    /// <summary>
    /// 対応するタスクを設定
    /// </summary>
    /// <param name="task"></param>
    public void SetTask(Task task)
    {
        this.task = task;
    }

    public void OnTriggerStay(Collider other)
    {
        if (!isGoal && other.gameObject.tag == "Player")
        {
            stayTime += Time.deltaTime;
            if (stayTime >= 1f)
            {
                isGoal = true;
                Debug.Log("Goal");
                task.IsClear();
            }
        }
    }
}
