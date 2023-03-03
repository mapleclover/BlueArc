using System;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField]private string teacherName = "NoName";
    [SerializeField]private int teacherLevel = 1;
    [SerializeField]private int myExp = 0;
    [SerializeField]private int myStamina = 24;
    [SerializeField]private int myCredit = 0;
    [SerializeField]private int myCash = 0;

    [SerializeField]private int myRecruitmentPoint = 0;

    public string TeacherName
    {
        get => teacherName;
        set => teacherName = value;
    }
    public int TeacherLevel
    {
        get => teacherLevel;
        set => teacherLevel = value;
    }
    public int MyExp 
    {
        get => myExp;
        set => myExp = value;
    }
    public int MyStamina 
    {
        get => myStamina;
        set => myStamina = value;
    }
    public int MyCredit 
    {
        get => myCredit;
        set => myCredit = value;
    }
    public int MyCash
    {
        get => myCash;
        set => myCash = value;
    }
    public int MyRecruitmentPoint
    {
        get => myRecruitmentPoint;
        set => myRecruitmentPoint = value;
    }

    public PlayerData(string name = "NoName", int level = 1, int exp = 0, int stamina = 24, int credit = 0,
        int cash = 0, int Rpoint = 0)
    {
        this.teacherName = name;
        this.teacherLevel = level;
        this.myExp = exp;
        this.myStamina = stamina;
        this.myCredit = credit;
        this.myCash = cash;
        this.myRecruitmentPoint = Rpoint;
    }
}
[Serializable]
public class CharacterData
{
    [SerializeField] private string _name; //학생 이름
    [SerializeField] private int _acquiredNumber;
    [SerializeField] private string _combatClass;
    [Header("ChangingStat")]
    [SerializeField] private int _rarity;
    [SerializeField] private int _level;
    [SerializeField] private int _attackType;
    [SerializeField] private int _exp;
    [SerializeField] private int _skillExLevel;
    [SerializeField] private int _skill1Level;
    [SerializeField] private int _skill2Level;
    [SerializeField] private int _skill3Level;
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    public int AcquiredNumber
    {
        get => _acquiredNumber;
        set => _acquiredNumber = value;
    }
    public int Rarity
    {
        get => _rarity;
        set => _rarity = value;
    }
    public int Level
    {
        get => _level;
        set => _level = value;
    }
    public int AttackType
    {
        get => _attackType;
        set => _attackType = value;
    }
    public int Exp
    {
        get => _exp;
        set => _exp = value;
    }
    public int SkillExLevel
    { 
        get =>_skillExLevel;
        set=> _skillExLevel = value;
    }

    public int Skill1Level
    {
        get => _skill1Level; 
        set => _skill1Level = value;
    }

    public int Skill2Level
    {
        get => _skill2Level;
        set => _skill2Level = value;
    }

    public int Skill3Level
    {
        get => _skill3Level;
        set => _skill3Level = value;
    }

    public string CombatClass
    {
        get => _combatClass;
        set => _combatClass = value;
    }
    
    public CharacterData(string name, int rarity, int attackType, string combatClass, int level = 1, int exp = 0, int skillEx = 1, int skill1 = 1, int skill2 = 1, int skill3 = 1)
    {
        Name = name;
        Rarity = rarity;
        AttackType = attackType; 
        CombatClass = combatClass;
        AcquiredNumber = Player.Instance.MyStudents.Count;
        Level = level;
        Exp = exp;
        SkillExLevel = skillEx;
        Skill1Level = skill1;
        Skill2Level = skill2;
        Skill3Level = skill3;
    }
}

[Serializable]
public class ItemData
{
    public string Name { get; set; }
    public int Count { get; set; }

    public ItemData(string name, int count = 0)
    {
        Name = name;
        Count = count;
    }
}