using System.Collections.Generic;

public class Player : Singleton<Player>
{
    public PlayerData MyPlayer = new PlayerData();
    public List<CharacterData> MyStudents = new List<CharacterData>();
    public List<ItemData> MyItems = new List<ItemData>();

    public bool AddStudent(StudentData sd)
    {
        if (CheckDupStudent(sd))
        {
            int amount = 0;
            switch (sd.BaseRarity)
            {
                case 1:
                    amount = 1;
                    break;
                case 2:
                    amount = 10;
                    break;
                case 3:
                    amount = 50;
                    break;
            }
            AddItem(DataContainer.Instance.items[0], amount);
            return false;
        }
        CharacterData newCharacter = new CharacterData(sd.Name, sd.BaseRarity);
        MyStudents.Add(newCharacter);
        DataManager.Instance.Save();
        return true;
    }
    public bool CheckDupStudent(StudentData sd)
    {
        if (MyStudents.Count == 0)
            return false;
        else
        {
            for (int i = 0; i < MyStudents.Count; i++)
            {
                if (MyStudents[i].Name.Equals(sd.Name))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void AddItem(ObjectData od, int amount)
    {
        int index = CheckDupItem(od);
        if (index != -1)
        {
            MyItems[index].Count += amount;
            DataManager.Instance.Save();
            return;
        }
        ItemData newItem = new ItemData(od.Name, amount);
        MyItems.Add(newItem);
        DataManager.Instance.Save();
    }

    public int CheckDupItem(ObjectData od)
    {
        for (int i = 0; i < MyItems.Count; i++)
        {
            if (MyItems[i].Name.Equals(od.Name))
                return i;
        }
        return -1;
    }
}