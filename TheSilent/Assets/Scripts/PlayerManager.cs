using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject interactNotification;
    public int keyCount;

    public void PickupKey()
    {
        keyCount++;
        Debug.Log("Key Picked Up");
    }

    public void UseKey()
    {
        keyCount = Mathf.Max(0, keyCount - 1);
        Debug.Log("Key Used");
    }

    public void NotifyPlayer()
    {
        interactNotification.SetActive(true);
    }

    public void DeNotifyPlayer()
    {
        interactNotification.SetActive(false);
    }                           
}