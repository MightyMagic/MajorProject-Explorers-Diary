using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] int checkpointId;

    void ActivateCheckpoint()
    {
        if(CheckpointManager.instance.CheckIfCheckpointIsValid(checkpointId))
        {
            Debug.LogError("Checkpoint is not activated!");
            CheckpointManager.instance.UpdateCheckpointStatus(checkpointId, true);
        }
        else
        {
            Debug.LogError("Checkpoint is already activated or something is wrong!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.LogError("Updated the checkpoint!");
            ActivateCheckpoint();
        }
    }
}
