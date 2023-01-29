using System;
using UnityEngine;

[Serializable]
public class GachaRate
{
    public int rarity;
    [Range(1,1000)]
    public int rate;

    public StudentData[] rewardList;
}
