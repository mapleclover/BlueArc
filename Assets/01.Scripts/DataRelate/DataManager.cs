using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance = null;
    
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static DataManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    private void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Create);

            Data data = new Data();

            SavePlayer(data);
            SaveCharacters(data);
            SaveItems(data);
            
            bf.Serialize(file, data);

            file.Close();
        }
        catch (System.Exception)
        {
            //This is for handling errors;
            throw;
        }
    }
    
    private void SavePlayer(Data data)
    {
        data.MyPlayerData = Player.Instance.MyPlayer;
    }

    private void SaveCharacters(Data data)
    {
        data.MyCharacterData = Player.Instance.MyStudents;
    }

    private void SaveItems(Data data)
    {
        data.MyItemData = Player.Instance.MyItems;
    }
    
    private void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);

            Data data = (Data)bf.Deserialize(file);

            file.Close();

            LoadPlayer(data);
            LoadCharacters(data);
            LoadItems(data);
        }
        catch (System.Exception)
        {
            //This is for handling errors;
            throw;
        }
    }
    
    private void LoadPlayer(Data data)
    {
        Player.Instance.MyPlayer = data.MyPlayerData;
    }

    private void LoadCharacters(Data data)
    {
        Player.Instance.MyStudents = data.MyCharacterData;
    }

    private void LoadItems(Data data)
    {
        Player.Instance.MyItems = data.MyItemData;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Load();
        }
    }
}
