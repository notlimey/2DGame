using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SerializationManager
{
    public static bool Save(PlayerProfile player, bool saveExists)
    {
        if (Directory.Exists(Application.persistentDataPath + "/saves/" + player.playerName) && saveExists)
        {
            return false;
        }

        BinaryFormatter formatter = GetBinaryFormatter();


        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        if(!Directory.Exists(Application.persistentDataPath + "/saves/" + player.playerName ))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/" + player.playerName);
        }

        string path = Application.persistentDataPath + "/saves/" + player.playerName + "/" + player.playerName + ".dat";

        FileStream file = File.Create(path);

        formatter.Serialize(file, player);

        file.Close();

        Debug.Log("Success");

        return true;
    }

    public static PlayerProfile Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            PlayerProfile save = (PlayerProfile)formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            file.Close();
            return null;
        }
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
}
