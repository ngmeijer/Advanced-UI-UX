using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    private int schoolWeekIndex = 4;
    [SerializeField] private SO_Week[] schoolWeeks;
    private SO_Week activeWeek;

    [SerializeField] private TextMeshProUGUI schoolWeekText;

    [SerializeField] private UpdateDay[] dayInstances;

    private void Start()
    {
        updateWeekData();
    }

    private void updateWeekData()
    {
        activeWeek = schoolWeeks[schoolWeekIndex - 4];

        string currentWeekNumbers = "Week " + activeWeek.SchoolWeekNumber + "/" +
                                    activeWeek.YearWeekNumber;
        schoolWeekText.SetText(currentWeekNumbers);

        SO_Day[] weekDays = activeWeek.weekDays;

        int dayIndex = 0;
        
        foreach (SO_Day day in weekDays)
        {
            dayInstances[dayIndex].ChangeData(day);
            dayIndex++;
        }
    }

    public void DecrementWeekIndex()
    {
        if (schoolWeekIndex <= 4) return;
        schoolWeekIndex -= 1;
        updateWeekData();
    }

    public void IncrementWeekIndex()
    {
        if (schoolWeekIndex >= 8) return;
        schoolWeekIndex += 1;
        updateWeekData();
    }
}