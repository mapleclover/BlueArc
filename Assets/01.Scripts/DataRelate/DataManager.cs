using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public void Save()
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
            Debug.Log("성공적으로 저장되었습니다.");
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
    
    public bool Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);
            Debug.Log(Application.persistentDataPath);
            Data data = (Data)bf.Deserialize(file);

            file.Close();

            LoadPlayer(data);
            LoadCharacters(data);
            LoadItems(data);
            Debug.Log("성공적으로 로드되었습니다.");
        }
        catch (System.Exception)
        {
            return false;
        }

        return true;
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

    public void Delete()
    {
        try
        {
            File.Delete(Application.persistentDataPath + "/" + "SaveTest.dat");
            Debug.Log("성공적으로 삭제되었습니다.");
        }
        catch (System.Exception)
        {
            //This is for handling errors;
            throw;
        }
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
