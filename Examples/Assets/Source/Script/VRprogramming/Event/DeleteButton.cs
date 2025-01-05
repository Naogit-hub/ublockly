using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{

    public void DeleteXML()
    {
        GameManager.instance.DeleteXml("object" + GameManager.instance.curUniqueID);
    }

    public void DeleteALLXML()
    {
        GameManager.instance.DeleteAllXml();
    }
}
