using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    public string Scene_Name;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick(){
        print ("Scene changed to"+Scene_Name);
        SceneManager.LoadScene(Scene_Name, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scene_Name));
        
    }
}
