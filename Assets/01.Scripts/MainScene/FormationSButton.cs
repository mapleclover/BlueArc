using UnityEngine;

public class FormationSButton : MonoBehaviour
{
    public int ButtonNumber = 0;
    public void OnButtonClick()
    {
        if (Player.Instance.MySpecialParty[this.ButtonNumber] != null)
        {
            Player.Instance.MySpecialParty[this.ButtonNumber] = null;
        }
    }
}
