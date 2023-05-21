using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDomo : MonoBehaviour
{
    private BoxCollider exitArea;
    private AudioSource doorSource;

    public GameObject player;
    public TextMeshProUGUI textEnter;

    [Header("Sound clip")]
    public AudioClip doorSound;

    [SerializeField] private bool onExitArea = false;

    // Start is called before the first frame update
    void Start()
    {
        doorSource = GetComponent<AudioSource>();
        onExitArea = GetComponent<BoxCollider>();
        onExitArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onExitArea)
        {
            doorSource.PlayOneShot(doorSound);
            player.transform.position = new Vector3(0.5f, 0.6f, 0);
            PlayerController.onDomo = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            onExitArea = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("entrou na area de entrada");
            textEnter.gameObject.SetActive(true);
            onExitArea = true;
            textEnter.text = "E para sair";
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("saiu da area de entrada");
            textEnter.gameObject.SetActive(false);
            onExitArea = false;
        }

    }
}
