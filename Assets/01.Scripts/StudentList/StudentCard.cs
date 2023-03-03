using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudentCard : MonoBehaviour
{
    [SerializeField]private Image StudentImage;
    [SerializeField]private TextMeshProUGUI DetailInfo;
    [SerializeField]private TextMeshProUGUI StudentName;
    [SerializeField]private StudentData sd;
    [SerializeField]private CharacterData cdContainer;

    [SerializeField]private StudentListManager _studentListManager;
    [SerializeField]private GameObject StudentStatus;

    [SerializeField] private Transform Canvas;

    private void Awake()
    {
        _studentListManager = FindObjectOfType<StudentListManager>();
        Canvas = FindObjectOfType<Canvas>().transform;
    }

    public void UpdateCard(CharacterData cd)
    {
        cdContainer = cd;
        for (int i = 0; i < DataContainer.Instance.students.Length; i++)
        {
            StudentData temp = DataContainer.Instance.students[i];
            if (cd.Name.Equals(temp.Name))
            {
                sd = temp;
                break;
            }

            if (i == DataContainer.Instance.students.Length - 1)
            {
                Debug.LogError("해당캐릭터를 찾지 못했습니다.");
            }
        }

        StudentImage.sprite = sd.Picture;
        StudentName.text = sd.Name;
    }

    private void Update()
    {
        switch ((int)_studentListManager.SortingStyle)
        {
            case 0:
                DetailInfo.text = $"Lv.{cdContainer.Level}";
                break;
            case 1:
                DetailInfo.text = $"<color=yellow>{cdContainer.Rarity}";
                break;
            case 2:
                if(cdContainer.AttackType == 0)
                    DetailInfo.text = $"<color=red>Explosive";
                else if(cdContainer.AttackType == 1)
                    DetailInfo.text = $"<color=yellow>Penetration";
                else if(cdContainer.AttackType == 2)
                    DetailInfo.text = $"<color=blue>Mystic";
                break;
        }
    }

    public void ButtonPressed()
    {
        GameObject obj = Instantiate(StudentStatus, Canvas);
        obj.GetComponent<StudentInfo>().SD = sd;
        obj.GetComponent<StudentInfo>().level = cdContainer.Level;
        obj.GetComponent<StudentInfo>().UpdateContent();
    }
}
