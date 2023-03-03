using UnityEngine;

public class StudentListButtonController : ButtonController
{
    [SerializeField] private StudentListManager _studentListManager;
    
    public void ReverseOrder()
    {
        _studentListManager.FlipList();
    }

    public void Sorting()
    {
        _studentListManager.SortStylePopUp();
    }
}
