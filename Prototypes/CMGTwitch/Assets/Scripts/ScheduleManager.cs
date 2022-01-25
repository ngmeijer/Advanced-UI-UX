using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour
{
    private int schoolWeekIndex = 4;
    [SerializeField] private SO_Week[] schoolWeeks;
    private SO_Week activeWeek;

    [SerializeField] private TextMeshProUGUI schoolWeekText;

    [SerializeField] private UpdateDay[] dayInstances;
    [SerializeField] private Image todaysBackground;
    private Color orange;
    private Color grey;
    private float alpha;

    private void Start()
    {
        updateWeekData();
        ColorUtility.TryParseHtmlString("#FD8726", out orange);
        ColorUtility.TryParseHtmlString("#1F1F1F", out grey);
        alpha = (157f / 255f);
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
        highlightCurrentDay();
    }

    public void IncrementWeekIndex()
    {
        if (schoolWeekIndex >= 8) return;
        schoolWeekIndex += 1;
        updateWeekData();
        highlightCurrentDay();
    }

    private void highlightCurrentDay()
    {
        if (schoolWeekIndex == 5) todaysBackground.color = orange;
        else
        {
            grey.a = alpha;
            todaysBackground.color = grey;
        }
    }
}