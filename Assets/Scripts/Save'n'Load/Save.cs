using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    public static void SavePlayer(playerMovement player, keyPickup key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.xd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, key);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.xd";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
                 
        }
    }
}
