using TMPro;
using UnityEngine;

public class RecruitmentPoint : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    private void Awake()
    {
        pointText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (pointText.text.Equals(Player.Instance.MyPlayer.MyRecruitmentPoint.ToString()))
        {
            return;
        }
        pointText.text = Player.Instance.MyPlayer.MyRecruitmentPoint.ToString();
    }
}
