using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormationButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IDropHandler
{
    public int[] list;
    private Vector3 originalPosition;
    [SerializeField]private float deltaCap;
    private Coroutine Counter = null;
    [SerializeField]private bool canDrag = false;
    [SerializeField]private int dragCount = 15;
    private Vector2 offset;
    public formation _formation;

    public int ButtonNumber;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Player.Instance.MyStrikerParty[this.ButtonNumber] != null)
        {
            Counter = StartCoroutine(beginCount());
            offset = (Vector2)this.transform.position - eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) 
        {
            if ((eventData.pressPosition - eventData.position).magnitude > deltaCap)
            {
                if (Counter != null)
                {
                    StopCoroutine(Counter);
                    Counter = null;
                }
            }
        }
        if (canDrag)
        {
            this.transform.position = eventData.position + offset;
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.transform.localPosition = originalPosition;
        if (Counter != null)
        {
            StopCoroutine(Counter);
            Counter = null;
        }

        if (!this.gameObject.GetComponent<Button>().interactable)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        this.gameObject.GetComponent<Image>().raycastTarget = true;
        canDrag = false;
    }

    IEnumerator beginCount()
    {
        int count = 0;
        while (count < dragCount)
        {
            count++;
            yield return null;
        }
        canDrag = true;
        this.transform.SetAsLastSibling();
        this.gameObject.GetComponent<Button>().interactable = false;
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        _formation.draggingIndex = this.ButtonNumber;
    }

    public void OnDrop(PointerEventData eventData)
    {
        _formation.SwapParty(this.ButtonNumber);
    }

    public void OnButtonClick()
    {
        if (Player.Instance.MyStrikerParty[this.ButtonNumber] != null)
        {
            Player.Instance.MyStrikerParty[this.ButtonNumber] = null;
        }
    }
}
