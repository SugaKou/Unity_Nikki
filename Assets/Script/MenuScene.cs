using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 2;
        int b = 3;
        Debug.Log((float)a / b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewDiary()
    {
        SceneManager.LoadScene("NewDiaryScene");
    } 
    [EnumAction(typeof(SceneList))]
    public void OnClick(int typeIndex)
    {
        SceneList scene = (SceneList)typeIndex;
        SceneManager.LoadScene(scene.ToString());
    }
    
}
public enum SceneList
{
    NewDiaryScene = 0,
    MenuScene,
    ViewDiaryScene
}