using System.Collections.Generic;

public class Player : Singleton<Player>
{
    public PlayerData MyPlayer = new PlayerData();
    public List<CharacterData> MyStudents = new List<CharacterData>();
    public List<ItemData> MyItems = new List<ItemData>();
    public CharacterData[] MyStrikerParty = new CharacterData[4];
    public CharacterData[] MySpecialParty = new CharacterData[2];


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
        CharacterData newCharacter = new CharacterData(sd.Name, sd.BaseRarity, (int)sd.AttackType, sd.CombatClass.ToString());
        MyStudents.Add(newCharacter);
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
            return;
        }
        ItemData newItem = new ItemData(od.Name, amount);
        MyItems.Add(newItem);
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

    public void AddParty(CharacterData ccd)
    {
        if (ccd.CombatClass.Equals("Striker"))
        {
            for (int i = 0; i < MyStrikerParty.Length; i++)
            {
                if (MyStrikerParty[i] == null)
                    continue;
                if (ccd.Name.Equals(MyStrikerParty[i].Name))
                {
                    MyStrikerParty[i] = null;
                    return;
                }
            }
            for (int i = 0; i < MyStrikerParty.Length; i++)
            {
                if (MyStrikerParty[i] == null)
                {
                    MyStrikerParty[i] = ccd;
                    return;
                }
            }
        }
        else if (ccd.CombatClass.Equals("Special"))
        {
            for (int i = 0; i < MySpecialParty.Length; i++)
            {
                if (MySpecialParty[i] == null)
                    continue;
                if (ccd.Name.Equals(MySpecialParty[i].Name))
                {
                    MySpecialParty[i] = null;
                    return;
                }
            }
            for (int i = 0; i < MySpecialParty.Length; i++)
            {
                if (MySpecialParty[i] == null)
                {
                    MySpecialParty[i] = ccd;
                    return;
                }
            }
        }
    }
}