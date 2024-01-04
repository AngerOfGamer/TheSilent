using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaken : MonoBehaviour
{
    public bool isTaken;

    public void takeItem()
    {
        if (!isTaken)
        {
            isTaken = true;
            Debug.Log("Item Taken");

            // Menonaktifkan objek setelah diambil
            gameObject.SetActive(false);
        }
    }
}
