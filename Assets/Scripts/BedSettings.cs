using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedSettings : MonoBehaviour
{
    private BoxCollider areaEnter;

    public TextMeshProUGUI textEnter;

    // Start is called before the first frame update
    void Start()
    {
        areaEnter = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            textEnter.text = "E para interagir com a cama";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            textEnter.gameObject.SetActive(false);
            Debug.Log("Saiu da area");
        }
    }
}
