using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField]
    private List<Goal> goalList;
    private bool isTaskComplete = false;
    private bool isTaskStart = false;

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

    public void StartTask()
    {
        isTaskStart = true;
        startTime = Time.time;
        Debug.Log("Task Start: " + startTime);
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
        isTaskComplete = true;
        this.gameObject.SetActive(false);
        return true;
    }
}