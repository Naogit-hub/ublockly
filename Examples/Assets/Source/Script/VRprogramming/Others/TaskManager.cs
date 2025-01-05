using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private List<Task> taskList;
    private int curTaskIndex = 0;

    public void Start()
    {
        foreach (Task task in taskList)
        {
            task.gameObject.SetActive(false);
        }
        // taskList[0].gameObject.SetActive(true);
    }

    public void SetCurrentTask(int index)
    {
        if (index < 0 || index >= taskList.Count)
        {
            Debug.LogError("Task index out of range");
            return;
        }
        curTaskIndex = index;
    }
    public void StartTask()
    {
        taskList[curTaskIndex].gameObject.SetActive(true);
        taskList[curTaskIndex].StartTask();
    }
}