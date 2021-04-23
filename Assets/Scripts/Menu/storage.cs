using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class storage : MonoBehaviour
{
    
    public class Data
    {
        public  int currentLevel = 0;
        public  List<float> records = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public  List<float> current = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public  bool eng = true;
        public float volume = 1f;
        public bool fpsShow = false;
        public int maxLevel = 9;
        public int menuVariant;
    }

    public static Data data;

    void Start()
    {
        
        LoadData();
        
        
        /*
        storage st = new storage();
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            st = JsonUtility.FromJson<storage>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }*/
    }
    public static void SaveRecord()
    {
        File.WriteAllText(Application.persistentDataPath + "/saveload.json", JsonUtility.ToJson(data));
    }
    // Update is called once per frame
    public  void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        else
        {
           File.WriteAllText(Application.persistentDataPath + "/saveload.json", JsonUtility.ToJson(this));
           data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        
    }
}
