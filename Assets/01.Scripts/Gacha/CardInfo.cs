using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public StudentData _studentData;
    
    [SerializeField] private Image BackImage;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private Image StarImage;

    [SerializeField] private Sprite[] SourceBackImage;
    [SerializeField] private Sprite[] SourceStarImage;
    [SerializeField] private Sprite SourceItem;

    [SerializeField] private GameObject NewCharacter;
    [SerializeField] private GameObject EligmaCount;
    
    public bool revealed = false;
    private Coroutine Coreveal;
    
    public bool _new;
    private bool cardRotate = true;

    [SerializeField]private int[] eligmas;
    private int rarityToInt;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        GachaSystem gachaSystem = FindObjectOfType<GachaSystem>();
        if(gachaSystem != null)
            gachaSystem.RevealOne();
    }
    public void UpdateCard()
    {
        switch(_studentData.BaseRarity)
        {
            case 3:
                rarityToInt = 0;
                break;
            case 2:
                rarityToInt = 1;
                break;
            case 1:
                rarityToInt = 2;
                break;
        }
        BackImage.sprite = SourceBackImage[rarityToInt];
        StarImage.sprite = SourceStarImage[rarityToInt];
        CharacterImage.sprite = _studentData.Picture;
    }

    public void RevealCard()
    {
        if (Coreveal != null)
            return;
        Coreveal = StartCoroutine(Revealing());
    }

    IEnumerator Revealing()
    {
        while (cardRotate)
        {
            if (this.transform.rotation.eulerAngles.y <= 90.0f)
            {
                if (BackImage.gameObject.activeSelf)
                {
                    BackImage.gameObject.SetActive(false);
                }
            }
            else if (this.transform.rotation.eulerAngles.y < 1.0f || this.transform.rotation.eulerAngles.y > 300.0f)
            {
                cardRotate = false;
                this.transform.rotation = Quaternion.identity;
            }
            this.transform.Rotate(Vector3.down);
            yield return null;
        }
        revealed = true;
        if (_new)
        {
            NewCharacter.SetActive(true);
        }
        if (!_new)
        {
            StartCoroutine(ItemInstead());
        }
    }

    IEnumerator ItemInstead()
    {
        while (true)
        {
            if (this.transform.rotation.eulerAngles.y > 90f && this.transform.rotation.eulerAngles.y <= 270f)
            {
                CharacterImage.sprite = SourceItem;
                StarImage.gameObject.SetActive(false);
                EligmaCount.GetComponent<TextMeshProUGUI>().text = $"X {eligmas[rarityToInt]}";
                EligmaCount.SetActive(true);
            }
            else
            {
                CharacterImage.sprite = _studentData.Picture;
                EligmaCount.SetActive(false);
                StarImage.gameObject.SetActive(true);
            }

            if (Mathf.Approximately(this.transform.rotation.eulerAngles.y, 180f))
                yield return new WaitForSeconds(1.0f);
            this.transform.Rotate(Vector3.down);
            yield return null;
        }
    }
}
