using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class storage
{
    
    public int currentLevel = 9;
    public List<float> records = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<float> current = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public bool eng = true;
    public float volume = 1f;

    
    void Start()
    {
        /*
        storage st = new storage();
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            st = JsonUtility.FromJson<storage>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }*/
    }
    public void SaveRecord()
    {
        storage st = new storage();
        File.WriteAllText(Application.persistentDataPath + "/saveload.json", JsonUtility.ToJson(st));
    }
    // Update is called once per frame
    public storage LoadData(storage stor)
    {
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            stor = JsonUtility.FromJson<storage>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        return stor;
    }
}
