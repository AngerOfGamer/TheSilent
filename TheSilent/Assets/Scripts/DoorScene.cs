using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScene : MonoBehaviour
{
    public bool isOpen;

    [SerializeField] private int keysRequired = 1;
    [SerializeField] private string targetSceneName; // Nama scene yang akan dituju

    public void OpenDoor(GameObject obj)
    {
        Debug.Log("Trying to open the door...");

        if (!isOpen)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = false;

                    // Mengurangkan key requirement
                    keysRequired--;

                    manager.UseKey();
                    Debug.Log("Door opened!");

                    if (keysRequired == 0)
                    {
                        isOpen = true;
                        Debug.Log($"All keys used. Teleporting to {targetSceneName}...");
                        SceneManager.LoadScene(targetSceneName);
                    }
                }
                else
                {
                    Debug.Log("Not enough keys to open the door!");
                }
            }
        }
    }
}
