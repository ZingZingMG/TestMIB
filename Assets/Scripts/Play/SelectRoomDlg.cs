using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class SelectRoomDlg : MonoBehaviour
{
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnClickClose()
    {
        Close();
    }

    public virtual void OnClickObserver()
    {
        Close();
    }

    public virtual void OnClickJoin()
    {
        Close();
    }
}