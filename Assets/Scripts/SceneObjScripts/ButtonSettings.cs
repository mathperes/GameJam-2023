using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSettings : MonoBehaviour
{
    private BoxCollider areaEnter;

    public TextMeshProUGUI textEnter;
    public GameObject panelAviso;

    private bool onArea = false;
    // Start is called before the first frame update
    void Start()
    {
        areaEnter = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArea)
        {
            panelAviso.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            onArea = true;
            textEnter.text = "E para interagir com o botão";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            textEnter.gameObject.SetActive(false);
            onArea = false;
            Debug.Log("Saiu da area");
        }
    }
}
