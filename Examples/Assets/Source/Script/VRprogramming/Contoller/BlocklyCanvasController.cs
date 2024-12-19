using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocklyCanvasController : MonoBehaviour
{
    public static BlocklyCanvasController instance = null;
    // [SerializeField]private Canvas blocklyCanvas;
    public ProgrammableObject p_object;
    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
