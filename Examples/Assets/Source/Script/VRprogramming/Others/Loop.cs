using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        List<Loop> loopList = GameManager.instance.loops;


        Loop next = loopList[Random.Range(0, loopList.Count)];

        Vector3 newPosition = next.transform.position + next.transform.forward * 3f;
        newPosition.y = other.transform.position.y;

        other.transform.position = newPosition;

        Vector3 newRotate = next.transform.rotation.eulerAngles;
        other.transform.rotation = Quaternion.Euler(newRotate);
    }
}
