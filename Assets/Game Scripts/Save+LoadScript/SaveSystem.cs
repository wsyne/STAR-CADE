
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (Player player)
    {
        //This creates the save file.
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.funcade";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.funcade";
        if (File.Exists(path))
        {
            //This loads the saved file.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            // turns save data back to a read-able file. 
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }

            
    }


}	