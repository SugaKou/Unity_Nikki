using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System;
public class DatePanel : MonoBehaviour
{
    [SerializeField] GameObject monthButtonPrefab;
    [SerializeField] RectTransform monthButtons;
    [SerializeField] RectTransform dayButtons;
    [SerializeField] Scrollbar scrollbar;
    public int selectedYear, selectedMonth, selectedDay;

    // Start is called before the first frame update
    void Start()
    {
        for (int a = 1; a <= 12; a++)
        {
            GameObject newObject = Instantiate(monthButtonPrefab);
            newObject.GetComponent<RectTransform>().SetParent(monthButtons);
            newObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            Text childText = newObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            childText.text = a.ToString();
            Button button = newObject.GetComponent<Button>();
            //Button.ButtonClickedEvent event = new Button.ButtonClickedEvent();
            button.onClick.AddListener(() => { OnClickMonth(a); });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickYear(int year)
    {
        selectedYear = year;
        GetComponent<PanelMove>().pageCount = 1;
    }
    void OnClickMonth(int month)
    {
        Debug.Log(month);
        selectedMonth = month;
        int days = 31;
        switch (month)
        {
            case 4:
            case 6:
            case 9:
            case 11:
                days = 30;
                break;

            case 2:
                if (selectedYear % 4 == 0 && (selectedYear % 100 != 0 || selectedYear % 400 == 0))
                {
                    days = 29;
                }
                else
                {
                    days = 28;
                }
                break;
        }
        dayButtons.sizeDelta = new Vector2(dayButtons.sizeDelta.x, 100 * days + 500);
        for (int a = 1; a <= days; a++)
        {
            GameObject newObject = Instantiate(monthButtonPrefab);
            newObject.GetComponent<RectTransform>().SetParent(dayButtons);
            newObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            Text childText = newObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            childText.text = a.ToString();
            Button button = newObject.GetComponent<Button>();
            var fileName = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-" + a.ToString();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                            + $"\\日記\\{fileName}.txt";
            Debug.Log(path);
            button.interactable = File.Exists(path);
            //Button.ButtonClickedEvent event = new Button.ButtonClickedEvent();
            button.onClick.AddListener(() => { OnClickDay(a); });
        }
        GetComponent<PanelMove>().pageCount = 2;
        scrollbar.value = 1;
    }
    void OnClickDay(int day)
    {
        selectedDay = day;
    }
}
