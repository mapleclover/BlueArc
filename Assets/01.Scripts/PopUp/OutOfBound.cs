using UnityEngine;
using UnityEngine.EventSystems;

public class OutOfBound : MonoBehaviour, IPointerClickHandler
{
    public GameObject parentObject;
    public bool Deactive = true;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Deactive)
        {
            parentObject.SetActive(false);
        }
        else
        {
            Destroy(parentObject);
        }
    }
}
