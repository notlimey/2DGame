using Assets.Scripts.Saving_and_Loading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SavePlayer(PlayerProfile player, bool saveExists)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }
        if (saveExists == true)
        {
            Debug.LogError(" - File already exists");
            return;
        }
        else
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/" + player.PlayerName + "/");
        }

        

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves/" + player.PlayerName + "/" + player.PlayerName + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, player);
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

    public static void SaveSettings(Settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, settings);
        stream.Close();
    }

    public static Settings LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.dat";
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);



        try
        {
            Settings save = (Settings)formatter.Deserialize(file);
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
}
