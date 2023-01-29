using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObject/Object")]
public class ObjectData : ScriptableObject
{
    [SerializeField] private string _name; //아이템 이름
    [SerializeField] private Sprite _picture;
    public string Name
    {
        get => _name;
    }
    public Sprite Picture
    {
        get => _picture;
    }
}
