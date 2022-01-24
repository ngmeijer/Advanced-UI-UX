using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCourseData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI courseName;
    [SerializeField] private TextMeshProUGUI classTypeAndTeacher;
    [SerializeField] private TextMeshProUGUI locationAndTime;

    public void UpdateData(SO_Course pData)
    {
        courseName.SetText(pData.CourseName);
        classTypeAndTeacher.SetText(pData.ClassType + " | " + pData.TeacherCode);
        locationAndTime.SetText(pData.Location + " | " + pData.TimeFrame);
    }
}
