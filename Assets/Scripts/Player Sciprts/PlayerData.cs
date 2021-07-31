using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int keys;
    public float[] playerPosition;
    public float[] minotaurPosition;

    public PlayerData(playerMovement playerMovement, keyPickup keyPickup)
    {
        keys = keyPickup.key;

        playerPosition = new float[3];
        playerPosition[0] = playerMovement.transform.position.x;
        playerPosition[1] = playerMovement.transform.position.y;
        playerPosition[2] = playerMovement.transform.position.z;
    }
}
