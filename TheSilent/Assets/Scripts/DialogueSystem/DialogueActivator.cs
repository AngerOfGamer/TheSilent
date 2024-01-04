using UnityEngine;

public class DialogueActivator : MonoBehaviour, DialogueInteract
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            player.Interact = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            if (player.Interact is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interact = null;
            }
        }
    }
    public void Interact(PlayerMovement player)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                player.DialogueUi.AddResponseEvents(responseEvents.Events);
                break;
            }
        }

        player.DialogueUi.ShowDialogue(dialogueObject);
    }
}
