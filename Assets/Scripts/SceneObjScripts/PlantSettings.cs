using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantSettings : MonoBehaviour
{
    private BoxCollider areaEnter;
    private StatusController statusControl;
    private TimerController timerControl;

    private bool onArea = false;
    [SerializeField]private float timeAdd = 20;

    public TextMeshProUGUI textEnter;

    // Start is called before the first frame update
    void Start()
    {
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
            timerControl.timePlant += timeAdd;
            if (timerControl.timePlant >= timerControl.plantSlider.maxValue)
            {
                timerControl.timePlant = timerControl.plantSlider.maxValue;
            }

            statusControl.withWater = false;
            statusControl.withObj = false;
            textEnter.gameObject.SetActive(false);
        }      

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
        yield return new WaitForSeconds(3);
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
