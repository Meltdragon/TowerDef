using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsUpgrade", menuName = "Stats Upgrade", order = 1)]
public class StatsUpgrade : ScriptableObject
{
    public AnimationCurve healthUpgradeInPercent;
    public AnimationCurve movementSpeedUpgradeInPercent;
}