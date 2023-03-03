using UnityEngine;
using UnityEngine.UI;

public class FormationStudentCard : MonoBehaviour
{
    public Image StudentImage;
    public Image Outline;
    public CharacterData cd;
    public StudentData sd;

    public void UpdateCard(CharacterData ccd)
    {
        cd = ccd;
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
        if (cd.CombatClass.Equals("Striker"))
        {
            Outline.color = Color.red;
        }
        else
        {
            Outline.color = Color.blue;
        }
    }

    public void ButtonPressed()
    {
        Player.Instance.AddParty(cd); 
    }
}
