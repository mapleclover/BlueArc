using TMPro;
using UnityEngine;

public class EnteringName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI InputField;

    public void InputName()
    {
        Player.Instance.MyPlayer.TeacherName = InputField.text;
        DataManager.Instance.Save();
        SceneLoad.Instance.ChangeScene("02.Main");
    }
}
