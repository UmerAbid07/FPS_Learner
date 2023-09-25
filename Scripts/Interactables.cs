using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    public string promptMessage;

    public void baseinterect()
    {
        interact();
        Debug.Log("isopen");
    }
    protected virtual void interact()
    {

    }
    

    // Start is called before the first frame update
}

