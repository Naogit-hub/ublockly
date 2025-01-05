using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : MonoBehaviour
{
    private Rigidbody rb;
    private int id;
    public int ID
    {
        get { return id; }
        set { id = value; }
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
            p_object.DefaultXML = "object" + id;
            Debug.Log("読み込み中: " + p_object.DefaultXML);
            Destroy(this.gameObject);
        }
    }
}
