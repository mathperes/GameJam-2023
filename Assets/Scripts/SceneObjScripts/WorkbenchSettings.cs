using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkbenchSettings : MonoBehaviour
{
    private StatusController statusControl;
    private TimerController timerControl;
    private BoxCollider areaEnter;

    private bool onArea = false;
    private bool trashOnTable = false;

    public TextMeshProUGUI textEnter;
    public SpriteRenderer bancadaComComida;
    public SpriteRenderer bancadaSemComida;


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

        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withObj == false && trashOnTable)
        {
            statusControl.withTrash = true;
            statusControl.withObj = true;
            trashOnTable = false;
            statusControl.comLixo.gameObject.SetActive(true);
            textEnter.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withFood && !trashOnTable)
        {
            StartCoroutine(PreparandoComidaCountdown());
        }

    }

    void PreparandoComida()
    {
        statusControl.withFood = false;
        statusControl.withObj = false;
        statusControl.comComida.gameObject.SetActive(false);
        trashOnTable = true;

        textEnter.text = "Pronto";

        timerControl.timeHungry += 30;

        if (timerControl.timeHungry >= timerControl.hungrySlider.maxValue)
        {
            timerControl.timeHungry = timerControl.hungrySlider.maxValue;
        }
    }

    IEnumerator PreparandoComidaCountdown()
    {
        PlayerController.canMove = false;
        textEnter.text = "Preparando comida";
        yield return new WaitForSeconds(3);
        PreparandoComida();
        PlayerController.canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);
            textEnter.text = "E para interagir com a bancada";

            if (statusControl.withFood)
            {
                textEnter.text = "E para preparar a comida";
            }
            if (trashOnTable)
            {
                textEnter.text = "E para coletar o lixo";
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
        }

        onArea = false;
    }
}
