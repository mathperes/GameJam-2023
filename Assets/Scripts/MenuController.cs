using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : ButtonController
{
    private AudioSource buttonSource;

    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonSource = GetComponent<AudioSource>();
    }

    public override void LoadSceneOption(int sceneNum)
    {
        buttonSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene(sceneNum);
    }

    public override void SetDisable(GameObject gameOb)
    {
        buttonSource.PlayOneShot(buttonSound);
        gameOb.SetActive(false);
    }

    public override void SetEnable(GameObject gameOb)
    {
        buttonSource.PlayOneShot(buttonSound);
        gameOb.SetActive(true);
    }
}
