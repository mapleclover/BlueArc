using TMPro;
using UnityEngine;

public class StudentInfo : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public StudentData SD;
    public int level;
    
    public void UpdateContent()
    {
        texts[0].text = ((int)(SD.MaxHp + SD.MaxHp * level * 0.1f)).ToString();
        texts[1].text = ((int)(SD.Attack + SD.Attack * level * 0.1f)).ToString();
        texts[2].text = ((int)(SD.Defense + SD.Defense * level * 0.1f)).ToString();
        texts[3].text = ((int)(SD.Healing + SD.Healing * level * 0.1f)).ToString();
        texts[4].text = SD.Accuracy.ToString();
        texts[5].text = SD.Evasion.ToString();
        texts[6].text = SD.CritRate.ToString();
        texts[7].text = SD.CritDamage.ToString();
        texts[8].text = SD.Stability.ToString();
        texts[9].text = SD.Range.ToString();
        texts[10].text = SD.ccStrength.ToString();
        texts[11].text = SD.ccResist.ToString();
        texts[12].text = SD.CostRecovery.ToString();
        texts[13].text = SD.Urban.ToString();
        texts[14].text = SD.Outdoors.ToString();
        texts[15].text = SD.Indoors.ToString();
    }
}
