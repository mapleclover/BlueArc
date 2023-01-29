using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject enterPlayerName;
    [SerializeField] private bool DataPresent;
    
    private void Awake()
    {
        DataPresent = DataManager.Instance.Load();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!DataPresent)
            {
                enterPlayerName.SetActive(true);                
            }
            else
            {
                SceneLoad.Instance.ChangeScene("02.Main");
            }
        }
    }
}
