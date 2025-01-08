using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private List<Task> taskList;
    private int selectedTaskIndex = 0;
    private Task curTask = null;
    public void Start()
    {
        foreach (Task task in taskList)
        {
            task.gameObject.SetActive(false);
        }
        // taskList[0].gameObject.SetActive(true);
    }

    public void SetTaskIndex(int index)
    {
        if (index < 0 || index >= taskList.Count)
        {
            Debug.LogError("Task index out of range");
            return;
        }
        selectedTaskIndex = index;
    }
    public void StartTask()
    {
        if(curTask != null)
        {
            curTask.StopTask();
            curTask.gameObject.SetActive(false);
        }

        curTask = taskList[selectedTaskIndex];
        curTask.gameObject.SetActive(true);
        curTask.StartTask();
    }

    public void ResetPosition()
    {
        curTask.ResetTaskObjects();
    }
}