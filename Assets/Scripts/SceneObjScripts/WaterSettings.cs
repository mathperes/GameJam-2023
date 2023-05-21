using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterSettings : MonoBehaviour
{
    private BoxCollider areaEnter;

    public TextMeshProUGUI textEnter;
    public StatusController statusControl;

    private bool onArea = false;

    // Start is called before the first frame update
    void Start()
    {
        areaEnter = GetComponent<BoxCollider>();
        statusControl = GameObject.Find("GameManager").GetComponent<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withObj == false)
        {
            statusControl.withObj = true;
            statusControl.withWater = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            textEnter.text = "E para pegar agua";

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
