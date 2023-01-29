using UnityEngine;
using TMPro;
public class DataDebug : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.MyItems.Count > 0)
        {
            text.text = Player.Instance.MyItems[0].Count.ToString();
        }
    }
}
