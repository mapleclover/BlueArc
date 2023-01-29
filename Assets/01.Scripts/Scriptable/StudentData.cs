using UnityEngine;

[CreateAssetMenu(fileName = "Student", menuName = "ScriptableObject/Student")]
public class StudentData : ScriptableObject
{
    [SerializeField] private int[] _requireExp; //학생 경험치 고정
    
    [SerializeField] private string _name; //학생 이름
    [SerializeField] private int _baseRarity;
    [SerializeField] private Sprite _picture;
    [SerializeField] private Sprite _fullPicture;
    
    [Header("ChangingStat")]
    [SerializeField] private int _maxHP;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _healing;
    
    [Header("ConstantStat")]
    [SerializeField] private int _accuracy;
    [SerializeField] private int _evasion;
    [SerializeField] private int _critRate;
    [SerializeField] private int _critDamage;
    [SerializeField] private int _stability;
    [SerializeField] private int _range;
    [SerializeField] private int _ccStrength;
    [SerializeField] private int _ccResist;
    [SerializeField] private int _attackSpeed;
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _costRecovery;
    [SerializeField] private int[] _ammo;

    [Header("Detail")] 
    [SerializeField] private school _school;
    [SerializeField] private role _role;
    [SerializeField] private position _position;
    [SerializeField] private attackType _attackType;
    [SerializeField] private armorType _armorType;
    [SerializeField] private combatClass _combatClass;
    [SerializeField] private weaponType _weaponType;
    [SerializeField] private item1Type _item1Type;
    [SerializeField] private item2Type _item2Type;
    [SerializeField] private item3Type _item3Type;
    [SerializeField] private bool _cover;
    [SerializeField] private affinity _urban;
    [SerializeField] private affinity _outdoors;
    [SerializeField] private affinity _indoors;

    [Header("Skill")] 
    [SerializeField] private int _skillCost;
    [SerializeField] private string[] _skillName;
    [SerializeField] private string[] _skillDesc;

    public enum school
    {
        Millennium, Gehenna, Arius, Trinity, RedWinter, Hyakkiyako, Abydos, Valkyrie, Shanhaijing, SRT
    }
    public enum role
    {
        Attacker, Support, Tank, TacticalSupport, Healer,
    }
    public enum position
    {
        Back, Middle, Front
    }
    public enum attackType
    {
        Explosive, Penetration, Mystic
    }
    public enum armorType
    {
        Light, Heavy, Special
    }
    public enum combatClass
    {
        Striker, Special
    }
    public enum weaponType
    {
        AR, FT, GL, HG, MG, MT, RG, RL, SG, SMG, SR
    }
    public enum item1Type
    {
        Cap, Glove, Shoe
    }
    public enum item2Type
    {
        Hairpin,Badge,Bag
    }
    public enum item3Type
    {
        Watch, Charm, Necklace
    }
    public enum affinity
    {
        D,C,B,A,S,SS
    }
    
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int BaseRarity
    {
        get => _baseRarity;
    }
    public int[] RequireExp
    {
        get => _requireExp;
    }
    public int MaxHp
    {
        get => _maxHP;
    }
    public int Attack
    {
        get => _attack;
    }
    public int Defense
    {
        get => _defense;
    }
    public int Healing
    {
        get => _healing;
    }
    public int Accuracy
    {
        get => _accuracy;
    }
    public int Evasion
    {
        get => _evasion;
    }
    public int CritRate
    {
        get => _critRate;
    }
    public int CritDamage
    {
        get => _critDamage;
    }
    public int Stability
    {
        get => _stability;
    }
    public int Range
    {
        get => _range;
    }
    public int ccStrength
    {
        get => _ccStrength;
    }
    public int ccResist
    {
        get => _ccResist;
    }
    public int AttackSpeed
    {
        get => _attackSpeed;
    }
    public int MoveSpeed
    {
        get => _moveSpeed;
    }
    public int CostRecovery
    {
        get => _costRecovery;
    }
    public int[] Ammo
    {
        get => _ammo;
    }
    public bool Cover
    {
        get => _cover;
    }
    public affinity Urban
    {
        get => _urban;
    }
    public affinity Outdoors
    {
        get => _outdoors;
    }
    public affinity Indoors
    {
        get => _indoors;
    }
    public school School
    {
        get => _school;
    }
    public role Role
    {
        get => _role;
    }
    public position Position
    {
        get => _position;
    }
    public attackType AttackType
    {
        get => _attackType;
    }
    public armorType ArmorType
    {
        get => _armorType;
    }
    public combatClass CombatClass
    {
        get => _combatClass;
    }
    public weaponType WeaponType
    {
        get => _weaponType;
    }
    public int SkillCost
    {
        get => _skillCost;
    }
    public item1Type Item1Type
    {
        get => _item1Type;
    }
    public item2Type Item2Type
    {
        get => _item2Type;
    }
    public item3Type Item3Type
    {
        get => _item3Type;
    }
    public Sprite Picture
    {
        get => _picture;
    }
    public Sprite FullPicture
    {
        get => _fullPicture;
    }
}
