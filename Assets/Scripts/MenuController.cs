using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : ButtonController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void LoadSceneOption(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public override void SetDisable(GameObject gameOb)
    {
        gameOb.SetActive(false);
    }

    public override void SetEnable(GameObject gameOb)
    {
        gameOb.SetActive(true);
    }
}
