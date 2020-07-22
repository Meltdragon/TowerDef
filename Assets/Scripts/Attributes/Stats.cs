using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats", order = 1)]
public class Stats : ScriptableObject
{
    public int health;
    public int movementSpeed;
}