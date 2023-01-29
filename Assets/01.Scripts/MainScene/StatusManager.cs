using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public TeacherData teacherData;
    [SerializeField]private TextMeshProUGUI teacherNameText;
    [Header("ExpRelate")]
    [SerializeField]private TextMeshProUGUI expText;
    [SerializeField]private TextMeshProUGUI levelText;
    [SerializeField]private Slider expSlider;
    [SerializeField]private Image fillColor;
    
    [Header("StaminaRelate")]
    [SerializeField]private TextMeshProUGUI staminaText;
    
    [Header("CreditRelate")]
    [SerializeField]private TextMeshProUGUI creditText;
    
    [Header("CashRelate")]
    [SerializeField]private TextMeshProUGUI cashText;

    private void Start()
    {
        TeacherNameSetup();
        ExpSetup();
        StaminaSetup();
        CreditSetup();
        CashSetup();
    }
    
    private void Update()
    {
        ExpSetup();
        StaminaSetup();
        CreditSetup();
        CashSetup();
        
        CheckLevelUp();
    }

    private void TeacherNameSetup()
    {
        teacherNameText.text = Player.Instance.MyPlayer.TeacherName;
    }
    
    private void ExpSetup()
    {
        if (Player.Instance.MyPlayer.TeacherLevel == 0)//디버그용
        {
            Player.Instance.MyPlayer.TeacherLevel++;
        }
        
        if (Player.Instance.MyPlayer.TeacherLevel == 1)
        {
            expSlider.maxValue = teacherData.Exp[0];
            expSlider.minValue = 0;
            expSlider.value = Player.Instance.MyPlayer.MyExp;
            levelText.text = $"{Player.Instance.MyPlayer.TeacherLevel}";
            expText.text = $"{expSlider.value-expSlider.minValue}/{expSlider.maxValue-expSlider.minValue}";
        }
        else if (Player.Instance.MyPlayer.TeacherLevel == teacherData.Exp.Length)
        {
            Color maxLevelColor = new Color32(234, 233, 65, 255);
            fillColor.color = maxLevelColor;
            Player.Instance.MyPlayer.MyExp = (int)expSlider.maxValue;
            expText.color = Color.yellow;
            expText.text = $"MAX";
            levelText.text = $"{Player.Instance.MyPlayer.TeacherLevel}";
        }
        else
        {
            int value = 0;
            for (int i = 0; i < Player.Instance.MyPlayer.TeacherLevel; i++)
            {
                value += teacherData.Exp[i];
            }
            expSlider.maxValue = value;
            expSlider.minValue = value - teacherData.Exp[Player.Instance.MyPlayer.TeacherLevel - 1];
            expSlider.value = Player.Instance.MyPlayer.MyExp;
            expText.text = $"{expSlider.value-expSlider.minValue}/{expSlider.maxValue-expSlider.minValue}";
            levelText.text = $"{Player.Instance.MyPlayer.TeacherLevel}";
        }
    }

    private void CheckLevelUp()
    {
        while (Player.Instance.MyPlayer.MyExp > expSlider.maxValue)
        {
            Player.Instance.MyPlayer.TeacherLevel++;
            Player.Instance.MyPlayer.MyStamina += teacherData.Stamina[Player.Instance.MyPlayer.TeacherLevel - 1];
            ExpSetup();
        }
    }

    private void StaminaSetup()
    {
        staminaText.text = $"{Player.Instance.MyPlayer.MyStamina}/{teacherData.Stamina[Player.Instance.MyPlayer.TeacherLevel-1]}";
    }

    private void CreditSetup()
    {
        creditText.text = Player.Instance.MyPlayer.MyCredit.ToString("N0");
    }
    
    private void CashSetup()
    {
        cashText.text = Player.Instance.MyPlayer.MyCash.ToString("N0");
    }
}
