using Assets.Scripts.Saving_and_Loading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SerializationManager
{

    public static void SavePlayer(Player player)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }
        if (Directory.Exists(Application.persistentDataPath + "/saves/" + Player.Username + "/"))
        {
            Debug.LogError(" - File already exists");
            return;
        }
        else
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/" + Player.Username + "/");
        }

        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves/" + Player.Username + "/" + Player.Username + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerProfile data = new PlayerProfile(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerProfile LoadPlayer(string path)
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
