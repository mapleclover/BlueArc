using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.Instance.MyPlayer.MyExp += 100;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Player.Instance.MyPlayer.MyCredit += 100000;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Player.Instance.MyPlayer.MyCash += 1200;
        }
    }

    public void DeleteData()
    {
        DataManager.Instance.Delete();
    }
}
