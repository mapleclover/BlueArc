using System;
using System.Collections.Generic;

[Serializable]
public class Data
{
    public PlayerData MyPlayerData { get; set; }

    public List<CharacterData> MyCharacterData { get; set; }
    public List<ItemData> MyItemData { get; set; }
    public Data()
    {
        MyCharacterData = new List<CharacterData>();
        MyItemData = new List<ItemData>();
    }
}

[Serializable]
public class PlayerData
{
    public int TeacherLevel { get; set; }
    public int MyExp { get; set; }
    public int MyStamina { get; set; }
    public int MyCredit { get; set; }
    public int MyCash { get; set; }
    public PlayerData(int level = 1, int exp = 0, int stamina = 20, int credit = 0, int cash = 0)
    {
        this.TeacherLevel = level;
        this.MyExp = exp;
        this.MyStamina = stamina;
        this.MyCredit = credit;
        this.MyCash = cash;
    }
}

[Serializable]
public class CharacterData
{
    public int MyCharacterNumber { get; set; }
    public int MyCharacterLevel { get; set; }
    public int MyCharacterExp { get; set; }
    public int MySkillExLevel { get; set; }
    public int MySkill1Level { get; set; }
    public int MySkill2Level { get; set; }
    public int MySkill3Level { get; set; }

    public CharacterData(int name, int level = 1, int exp = 0, int skillEx = 1, int skill1 = 1, int skill2 = 0, int skill3 = 0)
    {
        MyCharacterNumber = name;
        MyCharacterLevel = level;
        MyCharacterExp = exp;
        MySkillExLevel = skillEx;
        MySkill1Level = skill1;
        MySkill2Level = skill2;
        MySkill3Level = skill3;
    }
}

[Serializable]
public class ItemData
{
    public int MyItemName { get; set; }
    public int MyStackCount { get; set; }

    public ItemData(int name, int count = 0)
    {
        MyItemName = name;
        MyStackCount = count;
    }
}