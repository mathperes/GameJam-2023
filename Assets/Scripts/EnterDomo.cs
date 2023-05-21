using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterDomo : MonoBehaviour
{
    private BoxCollider enterArea;
    private AudioSource doorSource;

    public GameObject player;
    public TextMeshProUGUI textEnter;

    [Header("Sound clip")]
    public AudioClip doorSound;

    [SerializeField] private bool onEnterArea = false;

    // Start is called before the first frame update
    void Start()
    {
        doorSource = GetComponent<AudioSource>();
        onEnterArea = GetComponent<BoxCollider>();
        onEnterArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onEnterArea)
        {
            doorSource.PlayOneShot(doorSound);
            player.transform.position = new Vector3(-2.5f, 0.6f, 6);
            PlayerController.onDomo = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            onEnterArea = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("entrou na area de entrada");
            textEnter.gameObject.SetActive(true);
            onEnterArea = true;
            textEnter.text = "E para entrar";
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("saiu da area de entrada");
            textEnter.gameObject.SetActive(false);
            onEnterArea = false;
        }

    }
}
