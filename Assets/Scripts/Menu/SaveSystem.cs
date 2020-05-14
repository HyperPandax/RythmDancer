using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{
    public static void SaveSongs(LoadInSaveFile save){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/songs.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SongData data = new SongData(save);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SongData loadSongs(){
        string path = Application.persistentDataPath + "/songs.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SongData data = formatter.Deserialize(stream) as SongData;
            stream.Close();
            return data;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

