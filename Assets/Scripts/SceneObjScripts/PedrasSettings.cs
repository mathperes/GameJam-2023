using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PedrasSettings : MonoBehaviour
{
    private StatusController statusControl;
    private TimerController timerControl;
    private BoxCollider areaEnter;
    private AudioSource pedraSource;

    public GameObject pedra1;
    public GameObject pedra2;
    public GameObject pedra3;
    public TextMeshProUGUI textEnter;
    public AudioClip pedraSound;

    private bool onArea = false;
    public int strikes = 0;

    // Start is called before the first frame update
    void Start()
    {
        pedraSource = GetComponent<AudioSource>();
        areaEnter = GetComponent<BoxCollider>();
        statusControl = GameObject.Find("GameManager").GetComponent<StatusController>();
        timerControl = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArea)
        {
            pedraSource.PlayOneShot(pedraSound);
            strikes++;
        }

        if (strikes == 1)
        {
            pedra1.gameObject.SetActive(false);
            SetEarthSprite(timerControl.terra1);
        }

        if (strikes == 2)
        {
            pedra2.gameObject.SetActive(false);
            SetEarthSprite(timerControl.terra2);
        }

        if (strikes == 3)
        {
            pedra3.gameObject.SetActive(false);
            SetEarthSprite(timerControl.terra3);
            PlayerController.isLive = false;
        }
    }

    void SetEarthSprite(SpriteRenderer sprite)
    {
        timerControl.terraNormal.gameObject.SetActive(false);
        timerControl.terra1.gameObject.SetActive(false);
        timerControl.terra2.gameObject.SetActive(false);
        timerControl.terra3.gameObject.SetActive(false);
        timerControl.terraSeca.gameObject.SetActive(false);
        timerControl.terraSuja.gameObject.SetActive(false);

        sprite.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);

            textEnter.text = "E para jogar uma pedra";

            onArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            textEnter.gameObject.SetActive(false);
            Debug.Log("Saiu da area");

            onArea = false;
        }
    }
}
