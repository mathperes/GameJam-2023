using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedSettings : MonoBehaviour
{
    private BoxCollider areaEnter;
    private StatusController statusControl;
    private TimerController timerControl;

    public TextMeshProUGUI textEnter;
    public GameObject player;
    public GameObject bedWithOli;
    public GameObject bedWithOutOli;

    [SerializeField] private bool onArea = false;
    [SerializeField] private bool onBed = false;


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
        if (Input.GetKeyDown(KeyCode.E) && onArea && !statusControl.withObj)
        {
            player.gameObject.SetActive(false);
            bedWithOli.SetActive(true);
            bedWithOutOli.SetActive(false);
            StartCoroutine(SleepingCountdown());
            textEnter.gameObject.SetActive(false);
        }

        if (onBed)
        {
            timerControl.timeSleep += Time.deltaTime * 2;
        }
    }

    void Sleeping()
    {
        player.gameObject.SetActive(true);
        bedWithOli.SetActive(false);
        bedWithOutOli.SetActive(true);
    }

    IEnumerator SleepingCountdown()
    {
        onBed = true;
        yield return new WaitForSeconds(10);
        onBed = false;
        Sleeping();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            textEnter.text = "E para dormir";

            if (statusControl.withObj)
            {
                textEnter.text = "Você precisa estar sem item";
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
