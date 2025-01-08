using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField]
    private List<Goal> goalList;

    [SerializeField]
    private List<TaskObject> taskObjects;

    private bool isTaskComplete = false;
    public bool IsTaskComplete { get { return isTaskComplete; } }

    private bool isTaskRun = false;

    private float startTime;
    private float endTime;

    public void Awake()
    {
        Debug.Log("Task Awake");
        foreach (Goal goal in goalList)
        {
            goal.SetTask(this);
        }
    }

    /// <summary>
    /// タスクを開始する。
    /// </summary>
    public void StartTask()
    {
        ResetTaskObjects();
        if (!isTaskRun)
        {
            isTaskRun = true;
            startTime = Time.time;
            Debug.Log("Task Start: " + startTime);
        }
    }

    /// <summary>
    /// タスクを中止する。
    /// </summary>
    public void StopTask()
    {
        if (isTaskRun)
        {
            isTaskRun = false;
            startTime = 0;
            Debug.Log("タスクを中止しました。");
        }
    }


    /// <summary>
    /// タスクがクリアされたかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsClear()
    {
        foreach (Goal goal in goalList)
        {
            if (!goal.IsGoal)
            {
                return false;
            }
        }

        endTime = Time.time;
        Debug.Log("Task End: " + endTime);
        Debug.Log("Task Time: " + (endTime - startTime));
        isTaskRun = false;
        isTaskComplete = true;
        this.gameObject.SetActive(false);
        return true;
    }

    /// <summary>
    /// このタスクに登録されているTaskObject全体を初期位置に戻す。
    /// </summary>
    public void ResetTaskObjects()
    {
        GameManager.instance.p_ObjectDict.Clear();
        foreach (TaskObject taskObject in taskObjects)
        {
            GameManager.instance.p_ObjectDict.Add(taskObject.UniqueID, taskObject);
            Debug.Log("register- object: " + taskObject);
            taskObject.ResetObject();
        }
    }
}