using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPopup;
    
    public void OpenSetting()
    {
        settingPopup.SetActive(true);        
    }

    public void CloseSetting()
    {
        settingPopup.SetActive(false);
    }
}
