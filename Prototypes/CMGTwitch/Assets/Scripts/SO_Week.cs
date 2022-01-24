using System;
using UnityEngine;

[Serializable] [CreateAssetMenu(fileName = "SO_Week", menuName = "ScriptableObjects/SO_Week")]
public class SO_Week : ScriptableObject
{
    public int SchoolWeekNumber;
    public int YearWeekNumber;

    public SO_Day[] weekDays;
}
