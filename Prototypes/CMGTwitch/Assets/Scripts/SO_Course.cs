using System;
using UnityEngine;

[Serializable]
public enum E_TeacherCode
{
    HWI05,
    YJI01,
    DVA06,
    AMO02,
    TRO02,
}

[Serializable]
public enum E_ClassType
{
    Lecture,
    Lab
};

[Serializable] [CreateAssetMenu(fileName = "SO_Course", menuName = "ScriptableObjects/SO_Course")]
public class SO_Course : ScriptableObject
{
    public string CourseName;
    public E_TeacherCode TeacherCode;
    public E_ClassType ClassType;
    public string TimeFrame;
    public string Location;
}