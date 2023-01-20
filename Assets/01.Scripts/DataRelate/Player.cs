using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Player Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    public PlayerData MyPlayer;
    public List<CharacterData> MyStudents;
    public List<ItemData> MyItems;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MyPlayer.MyExp += 100;
        }
    }
}

