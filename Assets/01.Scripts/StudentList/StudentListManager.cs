using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudentListManager : MonoBehaviour
{
    public GameObject HorizontalList;
    public GameObject StudentCard;
    public Transform ContentHolder;

    private GameObject currentHorizontalList;

    private List<CharacterData> CharacterList;

    public sortingStyle SortingStyle = sortingStyle.Acquired;
    public bool Ascending = false;

    [SerializeField]private Image Background;
    [SerializeField]private Sprite[] Ascend;
    [SerializeField]private GameObject DecideSortPopUp;
    [SerializeField]private TextMeshProUGUI SortText;

    public enum sortingStyle
    {
        Level, Rarity, AttackType, Acquired, Name
    }
    public void Start()
    {
        ListUp();
    }

    public void ListUp()
    {
        CharacterList = Player.Instance.MyStudents;
        UpdateList();
    }
    
    public void SortStylePopUp()
    {
        DecideSortPopUp.SetActive(true);
    }
    public void FlipList()
    {
        CharacterList.Reverse();
        Ascending = !Ascending;
        if (Ascending)
        {
            Background.sprite = Ascend[0];
        }
        else
        {
            Background.sprite = Ascend[1];
        }
        UpdateList();
    }

    public void SortingList(sortingStyle ss)
    {
        if (SortingStyle == ss) return;
        SortingStyle = ss;
        switch (ss)
        {
            case sortingStyle.Level :
                SortText.text = "Level";
                CharacterList.Sort((CharacterData c1, CharacterData c2) => c1.Level.CompareTo(c2.Level));
                break;
            case sortingStyle.Rarity :
                SortText.text = "Rarity";
                CharacterList.Sort((CharacterData c1, CharacterData c2) => c1.Rarity.CompareTo(c2.Rarity));
                break;
            case sortingStyle.AttackType :
                SortText.text = "Attack Type";
                CharacterList.Sort((CharacterData c1, CharacterData c2) => c1.AttackType.CompareTo(c2.AttackType));
                break;
            case sortingStyle.Acquired :
                SortText.text = "Date Acquired";
                CharacterList.Sort((CharacterData c1, CharacterData c2) => c1.AcquiredNumber.CompareTo(c2.AcquiredNumber));
                break;
            case sortingStyle.Name :
                SortText.text = "Name";
                CharacterList.Sort((CharacterData c1, CharacterData c2) => c1.Name.CompareTo(c2.Name));
                break;
        }

        if (Ascending)
        {
            CharacterList.Reverse();
        }
        UpdateList();
    }

    public void UpdateList()
    {
        if (ContentHolder.transform.childCount > 0)
        {
            for (int i = ContentHolder.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(ContentHolder.transform.GetChild(i).gameObject);
            }
        }
        
        int studentCount = CharacterList.Count;
        currentHorizontalList = null;
        int index = 0;
        while (index < studentCount)
        {
            if (currentHorizontalList == null)
            {
                currentHorizontalList = Instantiate(HorizontalList, ContentHolder);
            }

            if (currentHorizontalList.transform.childCount == 6)
            {
                currentHorizontalList = Instantiate(HorizontalList, ContentHolder);
            }
            GameObject student = Instantiate(StudentCard, currentHorizontalList.transform);
            student.GetComponent<StudentCard>()?.UpdateCard(CharacterList[index]);
            student.GetComponent<FormationStudentCard>()?.UpdateCard(CharacterList[index]);
            index++;
        }
    }
}
