using System;
using UnityEngine;
using UnityEngine.UI;

public class formation : MonoBehaviour
{
    public Button[] strikerbuttons;
    public Button[] specialbuttons;
    public Sprite UISprite;
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < strikerbuttons.Length; i++)
        {
            if (Player.Instance.MyStrikerParty[i] == null)
            {
                strikerbuttons[i].name = "X";
                strikerbuttons[i].image.sprite = UISprite;
                continue;
            }
              
            if (strikerbuttons[i].name != Player.Instance.MyStrikerParty[i].Name)
            {
                strikerbuttons[i].name = Player.Instance.MyStrikerParty[i].Name;
                strikerbuttons[i].image.sprite = findImage(Player.Instance.MyStrikerParty[i].Name);
                break;
            }
        }
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
}
