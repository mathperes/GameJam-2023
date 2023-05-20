using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitDomo : MonoBehaviour
{
    private BoxCollider exitArea;

    public GameObject player;
    public TextMeshProUGUI textEnter;

    [SerializeField] private bool onExitArea = false;

    // Start is called before the first frame update
    void Start()
    {
        onExitArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onExitArea)
        {
            player.transform.position = new Vector3(0.5f, 0.6f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrou na area de entrada");
        textEnter.gameObject.SetActive(true);
        onExitArea = true;
        textEnter.text = "E para sair";
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("saiu da area de entrada");
        textEnter.gameObject.SetActive(false);
        onExitArea = false;
    }
}