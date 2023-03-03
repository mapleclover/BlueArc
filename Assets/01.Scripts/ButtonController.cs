using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void MainButton()
    {
        SceneLoad.Instance.ChangeScene("02.Main");
    }
    public void StudentListButton()
    {
        SceneLoad.Instance.ChangeScene("03.StudentList");
    }
    public void RecruitButton()
    {
        SceneLoad.Instance.ChangeScene("04.Gacha");
    }
}
