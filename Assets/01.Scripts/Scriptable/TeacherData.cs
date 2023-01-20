using UnityEngine;

[CreateAssetMenu(fileName = "Teacher", menuName = "ScriptableObject/Teacher")]
public class TeacherData : ScriptableObject
{
    [SerializeField] private string _name; //선생 이름
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    [SerializeField] private int[] _exp;
    public int[] Exp
    {
        get => _exp;
    }

    [SerializeField] private int[] _stamina;
    public int[] Stamina
    {
        get => _stamina;
    }

}
