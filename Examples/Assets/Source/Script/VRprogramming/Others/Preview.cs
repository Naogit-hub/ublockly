using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    public void PreviewObject()
    {
        if (parent.transform.childCount > 0)
        {
            Destroy(parent.transform.GetChild(0));
            var obj = Instantiate(GameManager.curObject, parent.transform.position, Quaternion.identity, parent.transform);
            obj.transform.localScale = new Vector3(1.2f, 0.042f, 0.03f);
        }
    }
}
