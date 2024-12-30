using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton : MonoBehaviour
{
    public void Run()
    {
        GameManager.instance.Run();
    }
}
