using TMPro;
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class GachaSystem : MonoBehaviour
{
    [SerializeField] private GachaRate[] gacha;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject[] pullList;
    
    [SerializeField] private GameObject ensureBox;
    [SerializeField] private GameObject errorBox;
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private Vector3[] pos = new Vector3[10];
    [SerializeField] private GameObject result;
    [SerializeField] private TextMeshProUGUI ensureText;

    private int pullCount;

    public void CheckPull(int count)
    {
        pullCount = count;
        ensureText.text = $"Proceed to recruit with {120*count} Pyroxenes?";
        if (Player.Instance.MyPlayer.MyCash < count*120)
        {
            errorBox.SetActive(true);
        }
        else
        {
            ensureBox.SetActive(true);
        }
    }
    public void CloseErrorBox()
    {
        errorBox.SetActive(false);
    }

    public void CloseEnsureBox()
    {
        ensureBox.SetActive(false);
    }

    public void ConfirmResult()
    {
        if (CheckAllReveal())
        {
            parentCanvas.SetActive(false);
        }
    }

    public void Rerecruit()
    {
        if (CheckAllReveal())
        {
            CheckPull(pullCount);
        }
    }

    public bool CheckAllReveal()
    {
        int count = 0;
        for (int i = 0; i < pullList.Length; i++)
        {
            if (!pullList[i].GetComponent<CardInfo>().revealed)
            {
                count++;
                pullList[i].GetComponent<CardInfo>().RevealCard();
            }
        }

        if (count > 0)
            return false;
        return true;
    }
    
    public void Pull()
    {
        pullList = new GameObject[pullCount];
        Player.Instance.MyPlayer.MyCash -= pullCount * 120;
        if (result.transform.childCount > 0)
        {
            for (int i = result.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(result.transform.GetChild(i).gameObject);
            }
        }
        for (int k = 0; k < pullCount; k++)
        {
            int rand = Random.Range(1, 1001);
            for (int i = 0; i < gacha.Length; i++)
            {
                if (rand <= gacha[i].rate)
                {
                    pullList[k] = Instantiate(cardPrefab);
                    pullList[k].transform.SetParent(result.transform);
                    pullList[k].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    pullList[k].transform.localPosition = pos[k];
                    if (k == 9 && gacha[i].rarity == 1)
                    {
                        pullList[k].GetComponent<CardInfo>()._studentData = Reward(gacha[i].rarity+1, pullList[k]);
                    }
                    else
                    {
                        pullList[k].GetComponent<CardInfo>()._studentData = Reward(gacha[i].rarity, pullList[k]);
                    }
                    pullList[k].GetComponent<CardInfo>().UpdateCard();
                    parentCanvas.SetActive(true);
                    break;
                }
            }
        }
    }
    
    private StudentData Reward(int rarity, GameObject Card)
    {
        GachaRate gr = Array.Find(gacha, gl => gl.rarity == rarity);
        StudentData[] reward = gr.rewardList;
        int rand = Random.Range(0, reward.Length);
        if (Player.Instance.AddStudent(reward[rand]))
        {
            Card.GetComponent<CardInfo>()._new = true;
        }
        else
        {
            Card.GetComponent<CardInfo>()._new = false;
        }
        return reward[rand];
    }
}
