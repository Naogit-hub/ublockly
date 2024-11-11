using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammableObject : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    public void SetObject()
    {

    }
    public void ShowWorkSpace(){

    }

    public IEnumerator MoveForword()
    {
        rb.transform.Translate(0.1f,0,0);
        yield return null; 
    }
}
