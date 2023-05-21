using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantSettings : MonoBehaviour
{
    private BoxCollider areaEnter;
    private StatusController statusControl;
    private TimerController timerControl;

    public SpriteRenderer plantaViva;
    public SpriteRenderer plantaMorta;

    private bool onArea = false;
    [SerializeField] private float timeAdd = 20;

    public TextMeshProUGUI textEnter;

    private AudioSource plantSource;
    public AudioClip notSound;

    // Start is called before the first frame update
    void Start()
    {
        plantSource = GetComponent<AudioSource>();
        areaEnter = GetComponent<BoxCollider>();
        statusControl = GameObject.Find("GameManager").GetComponent<StatusController>();
        timerControl = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withObj == false)
        {
            StartCoroutine(ColhendoCountdown());
        }
        
        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withWater)
        {
            StartCoroutine(RegandoCountdown());
        }
        

        if (timerControl.timePlant <= 0)
        {
            plantaViva.gameObject.SetActive(false);
            plantaMorta.gameObject.SetActive(true);

        }
    }

    void Regando()
    {
        timerControl.timePlant += timeAdd;
        if (timerControl.timePlant >= timerControl.plantSlider.maxValue)
        {
            timerControl.timePlant = timerControl.plantSlider.maxValue;
        }

        statusControl.withWater = false;
        statusControl.withObj = false;
        statusControl.comAgua.gameObject.SetActive(false);
        textEnter.text = "Pronto";
    }

    IEnumerator RegandoCountdown()
    {
        PlayerController.canMove = false;
        textEnter.text = "Regando";
        yield return new WaitForSeconds(2);
        PlayerController.canMove = true;
        Regando();
    }

    void Colhendo()
    {
        statusControl.withFood = true;
        statusControl.withObj = true;
        statusControl.comComida.gameObject.SetActive(true);
        textEnter.text = "Pronto";
    }

    IEnumerator ColhendoCountdown()
    {
        PlayerController.canMove = false;
        textEnter.text = "Colhendo";
        yield return new WaitForSeconds(2);
        PlayerController.canMove = true;
        Colhendo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            if (statusControl.withWater)
            {
                textEnter.text = "E para regar as plantas";
            }
            else
            {
                textEnter.text = "E para interagir com as plantas";
            }

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
