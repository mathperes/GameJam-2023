using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashSettings : MonoBehaviour
{
    private BoxCollider areaEnter;
    private StatusController statusControl;
    private TimerController timerControl;
    private AudioSource trashSource;

    public TextMeshProUGUI textEnter;
    public SpriteRenderer lixo1;
    public SpriteRenderer lixo2;
    public SpriteRenderer lixo3;
    public AudioClip trashSound;

    public int trashAmount = 0;
    [SerializeField] private bool onArea = false;

    // Start is called before the first frame update
    void Start()
    {
        areaEnter = GetComponent<BoxCollider>();
        trashSource = GetComponent<AudioSource>();
        statusControl = GameObject.Find("GameManager").GetComponent<StatusController>();
        timerControl = GameObject.Find("GameManager").GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArea && !statusControl.withObj && trashAmount > 0)
        {
            //textEnter.gameObject.SetActive(false);
            StartCoroutine(IncinerateCountdown());
        }

        if (Input.GetKeyDown(KeyCode.E) && onArea && statusControl.withTrash)
        {
            statusControl.withTrash = false;
            statusControl.withObj = false;
            trashAmount++;
            statusControl.comLixo.gameObject.SetActive(false);
            textEnter.text = "E para incinerar o lixo";
        }

        if (trashAmount == 1)
        {
            lixo1.gameObject.SetActive(true);
            lixo2.gameObject.SetActive(false);
            lixo3.gameObject.SetActive(false);
        }

        if (trashAmount == 2)
        {
            lixo1.gameObject.SetActive(false);
            lixo2.gameObject.SetActive(true);
            lixo3.gameObject.SetActive(false);
        }

        if (trashAmount >= 3)
        {
            lixo1.gameObject.SetActive(false);
            lixo2.gameObject.SetActive(false);
            lixo3.gameObject.SetActive(true);
        }
    }

    void Incinerate()
    {
        PlayerController.canMove = true;
        trashAmount--;
    }

    IEnumerator IncinerateCountdown()
    {
        PlayerController.canMove = false;
        trashSource.PlayOneShot(trashSound);
        yield return new WaitForSeconds(3);
        Incinerate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("Entrou na area");
            textEnter.gameObject.SetActive(true);

            textEnter.text = "E para incinerar o lixo";

            if (statusControl.withTrash)
            {
                textEnter.text = "E para botar o lixo na lixeira";
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
