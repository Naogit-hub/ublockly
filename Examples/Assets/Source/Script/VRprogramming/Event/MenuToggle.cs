using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    public void ClickToggleMenu() {
        // Toggle t = GetComponent<Toggle>();
        // t.isOn = true;
        // Debug.Log(t.name);
        Debug.Log("aaaaa");
        return;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.name);    
    }
}
