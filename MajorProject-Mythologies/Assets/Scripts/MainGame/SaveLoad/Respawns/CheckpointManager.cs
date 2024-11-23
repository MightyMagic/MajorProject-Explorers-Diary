using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    [Header("Data")]
    [SerializeField]
    private List<CheckpointData> initialCheckpointList = new List<CheckpointData>();

    [SerializeField] GameObject player;
    [SerializeField] string currentSceneName;

    [SerializeField] SpawnPointData spawnPointData;

    private List<CheckpointData> checkpointList = new List<CheckpointData>();
    private string filePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);

            filePath = Path.Combine(Application.persistentDataPath, "checkpoints.json");
            Debug.LogError("Checkpoint file is in " + filePath);
            InitializeCheckpoints();
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        Debug.LogError("Respawning player");

        List<CheckpointData> activatedCheckpoints = checkpointList
        .FindAll(cp => cp.sceneName == currentSceneName && cp.isActivated);

        // Return the activated checkpoint with the largest index, or null if none found
        if (activatedCheckpoints.Count > 0)
        {
            player.gameObject.transform.position = spawnPointData.respawnPoints[activatedCheckpoints.Count - 1].respawnPoint.position;
               // activatedCheckpoints[activatedCheckpoints.Count - 1].spawnPosition;
        }
        else
        {
            Debug.LogError("No active checkpoints!");
        }
    }

    private void InitializeCheckpoints()
    {
        if (File.Exists(filePath))
        {
            LoadCheckpoints();
            if (IsCheckpointListUpdated())
            {
                checkpointList = new List<CheckpointData>(initialCheckpointList); // Use updated initial list
                SaveCheckpoints(); // Override file with the updated list
                Debug.Log("Checkpoint file overridden with updated initial checkpoint data.");
            }
            else
            {
                Debug.Log("Checkpoints loaded from file.");
            }
        }
        else
        {
            checkpointList = new List<CheckpointData>(initialCheckpointList); // Use the initial list if file doesn't exist
            SaveCheckpoints(); // Save the initial list to the file
            Debug.Log("Initial checkpoints saved to file.");
        }
    }

    private void LoadCheckpoints()
    {
        string json = File.ReadAllText(filePath);
        checkpointList = JsonUtility.FromJson<SerializableListWrapper<CheckpointData>>(json).list;
    }

    private void SaveCheckpoints()
    {
        string json = JsonUtility.ToJson(new SerializableListWrapper<CheckpointData>(checkpointList), true);
        File.WriteAllText(filePath, json);
    }

    // Method to check if the initialCheckpointList has been modified in the inspector
    private bool IsCheckpointListUpdated()
    {
        if (checkpointList.Count != initialCheckpointList.Count) return true;

        //for (int i = 0; i < checkpointList.Count; i++)
        //{
        //    var loadedCheckpoint = checkpointList[i];
        //    var initialCheckpoint = initialCheckpointList[i];
        //
        //    if (loadedCheckpoint.sceneName != initialCheckpoint.sceneName ||
        //        loadedCheckpoint.spawnPosition != initialCheckpoint.spawnPosition ||
        //        loadedCheckpoint.isActivated != initialCheckpoint.isActivated)
        //    {
        //        return true; // A difference was found
        //    }
        //}
        return false;
    }

    // Method to update the activation status of a checkpoint
    public void UpdateCheckpointStatus(int id, bool isActivated)
    {
        CheckpointData checkpoint = checkpointList.Find(cp => cp.checkPointId == id);

        if (checkpoint != null)
        {
            checkpoint.isActivated = isActivated;
            SaveCheckpoints(); // Save the updated status to the file
            Debug.Log($"Checkpoint #" + id + " updated to: {isActivated}");
        }
        else
        {
            Debug.LogWarning("Checkpoint not found.");
        }
    }

    public bool CheckIfCheckpointIsValid(int id)
    {
        CheckpointData checkpoint = checkpointList.Find(cp => cp.checkPointId == id);

        if (checkpoint != null)
        {
            if (!checkpoint.isActivated)
            {
                
                return true;
            }
            else { return false; }
        }
        else
        {
            return false;
        }
    }

    public void ResetAllCheckpoints()
    {
        LoadCheckpoints();
        for(int i = 0; i < checkpointList.Count; i++)
        {
            checkpointList[i].isActivated = false;
        }
        SaveCheckpoints();
    }
}
