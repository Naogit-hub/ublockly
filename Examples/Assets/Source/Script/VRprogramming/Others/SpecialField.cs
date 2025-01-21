using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialField : MonoBehaviour
{
    [SerializeField]
    private List<ProgrammableObject> fieldObjects;
    public void ResetFieldObjects()
    {
        GameManager.instance.p_ObjectDict.Clear();
        foreach (ProgrammableObject fieldObject in fieldObjects)
        {
            GameManager.instance.p_ObjectDict.Add(fieldObject.UniqueID, fieldObject);
            Debug.Log("register- object: " + fieldObject);
            fieldObject.ResetObject();
        }
    }
}
