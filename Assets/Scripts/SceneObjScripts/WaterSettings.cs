using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterSettings : MonoBehaviour
{
    private BoxCollider areaEnter;
    private AudioSource waterSoucer;

    public TextMeshProUGUI textEnter;
    public StatusController statusControl;

    [Header("Sound clip")]
    public AudioClip waterSound;

    private bool onArea = false;

    // Start is called before the first frame update
    void Start()
    {
        waterSoucer = GetComponent<AudioSource>();
        areaEnter = GetComponent<BoxCollider>();
        statusControl = GameObject.Find("GameManager").GetComponent<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withObj == false)
        {
            StartCoroutine(PegandoAguaCountdown());
        }
    }

    void PegandoAgua()
    {
        statusControl.withObj = true;
        statusControl.withWater = true;
        statusControl.comAgua.gameObject.SetActive(true);        
    }

    IEnumerator PegandoAguaCountdown()
    {
        PlayerController.canMove = false;
        textEnter.text = "Pegando Agua";
        waterSoucer.PlayOneShot(waterSound);
        yield return new WaitForSeconds(2);
        textEnter.text = "Pronto";
        PegandoAgua();
        PlayerController.canMove = true;

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
