using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class UpdateDay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI dateText;

    private SO_Day todaysProperties;
    private GameObject coursePrefab;
    [SerializeField] private Transform courseParent;

    private void Start()
    {
        loadPrefab();
    }

    private void loadPrefab()
    {
        coursePrefab =
            (GameObject) Resources.Load("CourseInstance");
        Debug.Log(coursePrefab);
    }

    public void ChangeData(SO_Day pDay_SO)
    {
        todaysProperties = pDay_SO;
        dayText.SetText(todaysProperties.Day.ToString());
        dateText.SetText(todaysProperties.Date);

        AddCourseInstances();
    }

    private float calculateVerticalOffset(string pTimeframe)
    {
        char[] hourChars = pTimeframe.ToCharArray();

        float position = -70;

        char[] fullHourChars = {hourChars[0], hourChars[1]};
        string hour = new string(fullHourChars);

        switch (hour)
        {
            case "09":
                position -= 0;
                break;
            case "10":
                position -= 70;
                break;
            case "11":
                position -= 140;
                break;
            case "12":
                position -= 210;
                break;
            case "13":
                position -= 280;
                break;
            case "14":
                position -= 350;
                break;
            case "15":
                position -= 420;
                break;
            case "16":
                position -= 490;
                break;
            case "17":
                position -= 560;
                break;
            case "18":
                position -= 630;
                break;
        }

        char[] halfHourChars = {hourChars[3], hourChars[4]};
        string halfOrQuarterHour = new string(halfHourChars);

        switch (halfOrQuarterHour)
        {
            case "15":
                position -= 20;
                break;
            case "30":
                position -= 40;
                break;
            case "45":
                position -= 60;
                break;
        }

        return position;
    }

    private void AddCourseInstances()
    {
        Debug.Log(todaysProperties);
        foreach (SO_Course courseInstance in todaysProperties.coursesToday)
        {
            if (coursePrefab == null) loadPrefab();

            float yPos = calculateVerticalOffset(courseInstance.TimeFrame);
            
            Debug.Assert(coursePrefab != null,$"{courseInstance.CourseName}, {todaysProperties.Date}");
            
            GameObject instance = Instantiate(coursePrefab,
                Vector3.zero,
                Quaternion.identity);
            instance.transform.SetParent(courseParent);
            instance.transform.localPosition = new Vector3(0, yPos, 0);
            instance.transform.localScale = new Vector3(1, 1, 1);

            UpdateCourseData dataProcessor = instance.GetComponent<UpdateCourseData>();
            dataProcessor.UpdateData(courseInstance);
        }
    }
}