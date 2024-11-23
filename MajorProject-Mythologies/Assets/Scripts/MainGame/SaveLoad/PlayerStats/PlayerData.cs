using UnityEngine;

public class PlayerData
{
    public int saveFileId;
    public int spawnActivationsLeft;
    public string latestSceneName;

    private string saveName = "Diary"+0.ToString();

    public PlayerData(int saveFileId, int spawnActivationsLeft, string latestSceneName)
    {
        this.saveFileId = saveFileId;
        this.spawnActivationsLeft = spawnActivationsLeft;
        this.latestSceneName = latestSceneName;

        saveName = "Diary"+ saveFileId.ToString();
    }
}
