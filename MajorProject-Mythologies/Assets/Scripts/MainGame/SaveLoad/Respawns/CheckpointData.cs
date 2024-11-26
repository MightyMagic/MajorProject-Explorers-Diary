using System;
using UnityEngine;

[System.Serializable]
public class CheckpointData
{
    public int checkPointId;
    public string sceneName;
    //public Vector3 spawnPosition;
    public bool isActivated;

    public CheckpointData(string sceneName, Vector3 spawnPosition, bool isActivated)
    {
        this.sceneName = sceneName;
        //this.spawnPosition = spawnPosition;
        this.isActivated = isActivated;
    }
}
