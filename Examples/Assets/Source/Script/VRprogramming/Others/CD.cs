using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : MonoBehaviour
{
    private Rigidbody rb;
    // private int id;
    // public int ID
    // {
    //     get { return id; }
    //     set { id = value; }
    // }

    private string xml;
    public string Xml
    {
        get { return xml; }
        set { xml = value; }
    }

    private ProgrammableObject p_object;

    public void Awake()
    {
        if (rb == null)
            rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public void ChangeRigidBodyStatus()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    /// <summary>
    /// 接触したオブジェクトにidを保存する
    /// </summary>
    /// <param name="other"></param>
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<ProgrammableObject>(out p_object))
        {
            if (p_object.IsReadOnly)
                return;

            p_object.DefaultXML = this.xml;
            Debug.Log("読み込み中: " + xml);
            Destroy(this.gameObject);
        }
    }
}
