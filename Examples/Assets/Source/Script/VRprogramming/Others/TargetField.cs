using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetField : MonoBehaviour
{
    private Vector3 targetPosition;

    private ProgrammableObject programmableObject;
    public Camera renderCamera; // Render Textureを使用しているカメラ
    public RenderTexture renderTexture; // 対象のRender Texture
 
    void Start()
    {
        if (renderCamera != null)
        {
            renderCamera.targetTexture = renderTexture;
            Vector3 tmp = renderCamera.transform.position;
            tmp.x += 2;
            targetPosition = tmp;
        }
    }

    void LateUpdate()
    {
        if (renderTexture != null)
        {
            // Render Textureをクリア
            RenderTexture activeRT = RenderTexture.active;
            RenderTexture.active = renderTexture;
            GL.Clear(true, true, Color.clear); // 背景を透明にクリア
            RenderTexture.active = activeRT;
        }
    }
    public void Update()
    {
        if (programmableObject != null)
        {
            Vector3 angle = programmableObject.transform.eulerAngles;
            angle.y += 0.06f;
            programmableObject.transform.eulerAngles = angle;
        }
    }

    public void SetTargetObject(ProgrammableObject p_Object)
    {
        if (programmableObject != null)
        {
            Debug.Log("Destroy");
            Destroy(programmableObject.gameObject);
        }
        ProgrammableObject targetObject = Instantiate(p_Object, targetPosition, Quaternion.identity);
        targetObject.transform.eulerAngles = new Vector3(-15f, 0f, 0f);
        targetObject.Menu.gameObject.SetActive(false);

        if (targetObject.GetComponent<Rigidbody>() != null)
        {
            targetObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        targetObject.transform.parent = this.transform;

        Debug.Log("SetTargetObject: " + targetObject);
        programmableObject = targetObject;
    }
}
