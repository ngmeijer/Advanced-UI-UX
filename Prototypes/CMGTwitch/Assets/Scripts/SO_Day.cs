using System;
using UnityEngine;

[Serializable]
public enum WeekDay
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

[Serializable] 
[CreateAssetMenu(fileName = "SO_Day", menuName = "ScriptableObjects/SO_Day")]
public class SO_Day : ScriptableObject
{
    public WeekDay Day;
    public string Date;
    public SO_Course[] coursesToday;
}