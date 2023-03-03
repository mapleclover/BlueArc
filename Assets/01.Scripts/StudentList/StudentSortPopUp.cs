
using UnityEngine.UI;
using UnityEngine;

public class StudentSortPopUp : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Sprite[] images;
    [SerializeField] private StudentListManager _studentListManager;
    public int SelectedType = 0;

    private void OnEnable()
    {
        SelectedType = (int)_studentListManager.SortingStyle;
        background.sprite = images[SelectedType];
    }

    public void SortTypeButtonPressed(int i)
    {
        if (SelectedType == i)
            return;
        SelectedType = i;
        background.sprite = images[SelectedType];
    }

    public void ConfirmButtonPressed()
    {
        _studentListManager.SortingList((StudentListManager.sortingStyle)SelectedType);
    }
}
