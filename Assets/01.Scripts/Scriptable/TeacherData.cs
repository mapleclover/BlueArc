using UnityEngine;

[CreateAssetMenu(fileName = "Teacher", menuName = "ScriptableObject/Teacher")]
public class TeacherData : ScriptableObject
{
    [SerializeField] private int[] _exp;
    [SerializeField] private int[] _stamina;

    public int[] Exp
    {
        get => _exp;
    }

    public int[] Stamina
    {
        get => _stamina;
    }
}
