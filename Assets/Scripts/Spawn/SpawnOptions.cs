using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnOption", menuName = "SpawnOptions", order = 1)]
public class SpawnOptions : ScriptableObject
{
    public List<GameObject> enemy;
    public AnimationCurve amountOfEnemies;
}