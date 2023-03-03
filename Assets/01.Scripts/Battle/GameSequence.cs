using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] private GameObject CharacterAvatarPrefab;
    [SerializeField] private Transform[] ResponePosition;
    [SerializeField] private GameObject[] Character = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        int StrikerCount = 0;
        foreach (CharacterData x in Player.Instance.MyStrikerParty)
        {
            if (x.CombatClass.Equals("Striker"))
                StrikerCount++;
        }

        for (int i = 0; i < StrikerCount; i++)
        {
            Character[i] = Instantiate(CharacterAvatarPrefab, ResponePosition[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
