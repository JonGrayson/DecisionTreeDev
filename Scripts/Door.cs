using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool isClosed = false;
    public bool isLocked = false;

    public Toggle locked;
    public Toggle closed;

    Vector3 closedRotation = new Vector3(0, 0, 0);
    Vector3 openRotation = new Vector3(0, -135, 0);

    public void Start()
    {
        if(isClosed)
        {
            transform.eulerAngles = closedRotation;
        }

        else
        {
            transform.eulerAngles = openRotation;
        }
    }

    public void Update()
    {
        isDoorLocked();
        isDoorClosed();
    }

    public bool Open()
    {
        if(isClosed && !isLocked)
        {
            isClosed = false;
            transform.eulerAngles = openRotation;
            return true;
        }

        return false;
    }

    public bool Close()
    {
        if(!isClosed)
        {
            transform.eulerAngles = closedRotation;
            isClosed = true;
        }

        return true;
    }

    public bool isDoorLocked()
    {
        if (locked.isOn == true)
        {
            isLocked = true;
            return true;
        }

        else
        {
            isLocked = false;
            return false;
        }
    }

    public bool isDoorClosed()
    {
        if (closed.isOn == true)
        {
            isClosed = true;
            Close();
            return true;
        }

        else
        {
            isClosed = false;
            Open();
            return false;
        }
    }
}
