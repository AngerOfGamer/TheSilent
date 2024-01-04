using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTeleport : MonoBehaviour
{
    public bool isInRange;
    private GameObject currentTeleporter;
    public UnityEvent interactAction;
    public UnityEvent notifyPlayer;
    public UnityEvent deNotifyPlayer;
    private bool isTeleporting = false;

    // Referensi ke komponen PlayerManager
    private PlayerManager playerManager;

    void Start()
    {
        // Mendapatkan referensi ke komponen PlayerManager
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isTeleporting)
            {
                interactAction.Invoke();
                if (currentTeleporter != null)
                {
                    Teleport();
                }
            }
        }
    }

    void Teleport()
    {
        isTeleporting = true;
        transform.position = currentTeleporter.GetComponent<DoorController>().GetDestination().position;
        isTeleporting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            isInRange = true;
            notifyPlayer.Invoke();

            // Meneruskan notifikasi ke PlayerManager
            playerManager.NotifyPlayer();

            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            isInRange = false;
            deNotifyPlayer.Invoke();
            playerManager.DeNotifyPlayer();
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}