using System;
using UnityEngine;
using UnityEngine.UI;

public class formation : MonoBehaviour
{
    public Button[] strikerbuttons;
    public Button[] specialbuttons;
    public Sprite UISprite;

    public GameObject[] leaderSign;
    [SerializeField]private int leader = -1;

    public int draggingIndex = -1;
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < strikerbuttons.Length; i++)
        {
            if (Player.Instance.MyStrikerParty[i] == null)
            {
                strikerbuttons[i].name = "X";
                strikerbuttons[i].image.sprite = UISprite;
                if (i == leader)
                    leader = -1;
                continue;
            }
              
            if (strikerbuttons[i].name != Player.Instance.MyStrikerParty[i].Name)
            {
                strikerbuttons[i].name = Player.Instance.MyStrikerParty[i].Name;
                strikerbuttons[i].image.sprite = findImage(Player.Instance.MyStrikerParty[i].Name);
                break;
            }
        }
        CalculateLeader();
        ShowLeaderSign();
        
        for (int i = 0; i < specialbuttons.Length; i++)
        {
            if (Player.Instance.MySpecialParty[i] == null)
            {
                specialbuttons[i].name = "X";
                specialbuttons[i].image.sprite = UISprite;
                continue;
            }
            if (specialbuttons[i].name != Player.Instance.MySpecialParty[i].Name)
            {
                specialbuttons[i].name = Player.Instance.MySpecialParty[i].Name;
                specialbuttons[i].image.sprite = findImage(Player.Instance.MySpecialParty[i].Name);
                break;
            }
        }
    }

    public void CalculateLeader()
    {
        if (leader < 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Player.Instance.MyStrikerParty[i] != null)
                {
                    leader = i;
                    return;
                }
            }
            leader = -1;
        }
    }

    private void ShowLeaderSign()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == leader)
            {
                leaderSign[i].SetActive(true);
            }
            else
            {
                leaderSign[i].SetActive(false);
            }
        }

        if (leader == -1)
        {
            foreach(GameObject x in leaderSign)
            {
                x.SetActive(false);
            }
        }
    }
    
    private Sprite findImage(string name)
    {
        try
        {
            for (int i = 0; i < DataContainer.Instance.students.Length; i++)
            {
                StudentData temp = DataContainer.Instance.students[i];
                if (name.Equals(temp.Name))
                {
                    return temp.Picture;
                }
            }
        }
        catch (Exception e)
        {
            return UISprite;
        }

        return UISprite;
    }

    public void SwapParty(int dropped)
    {
        if (draggingIndex == -1) return;
        (Player.Instance.MyStrikerParty[draggingIndex], Player.Instance.MyStrikerParty[dropped]) = (Player.Instance.MyStrikerParty[dropped], Player.Instance.MyStrikerParty[draggingIndex]);
        if (draggingIndex == leader)
        {
            leader = dropped;
        }
        else if (dropped == leader)
        {
            leader = draggingIndex;
        }
        draggingIndex = -1;
    }
}
