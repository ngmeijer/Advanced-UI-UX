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
        coursePrefab =
            (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/CourseInstance.prefab", typeof(GameObject));
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
        if(pTimeframe.Contains("stringToSearchFor"))
        {
            
        }

        return 0;
    }

    private void AddCourseInstances()
    {
        //Each interval is +- 40 px
        //So depending on timeframe, add x times 40px.
        foreach (SO_Course courseInstance in todaysProperties.coursesToday)
        {
            float yPos = calculateVerticalOffset(courseInstance.TimeFrame);
            
            GameObject instance = GameObject.Instantiate(coursePrefab,
                new Vector3(125, 280 + yPos,0),
                Quaternion.identity);
            instance.transform.SetParent(courseParent);
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localScale = new Vector3(1, 1, 1);

            UpdateCourseData dataProcessor = instance.GetComponent<UpdateCourseData>();
            dataProcessor.UpdateData(courseInstance);
        }
    }
}