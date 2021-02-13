using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryUI : MonoBehaviour
{
    [SerializeField] InputField titleInputField;
    [SerializeField] InputField mainTextInputField;
    [SerializeField] GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveDiary()
    {
        Debug.Log("※セーブ※");
        Debug.Log(titleInputField.text);
        Debug.Log(mainTextInputField.text);
        gameController.SaveDiaryToFile(titleInputField.text,mainTextInputField.text);

    }
}
