using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class GameController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello\nWorld");

    }
    public void SaveDiaryToFile(string title, string maintext)
    {
        var now = System.DateTime.Now;
        Debug.Log(now.Day.ToString());
        var fileName = now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString();
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                        + $"\\日記\\{fileName}.txt";
        if(File.Exists(path))
        {
            Debug.Log("すでに今日の日記があります。");
        }
        else
        {
            File.WriteAllText(path, title+"\n"+maintext);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
