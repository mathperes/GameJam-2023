using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterDomo : MonoBehaviour
{
    private BoxCollider enterArea;

    public GameObject player;
    public TextMeshProUGUI textEnter;

    [SerializeField]private bool onEnterArea = false;

    // Start is called before the first frame update
    void Start()
    {
        onEnterArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onEnterArea)
        {
            player.transform.position = new Vector3(-2.5f, 0.6f, 6);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrou na area de entrada");
        textEnter.gameObject.SetActive(true);
        onEnterArea = true;
        textEnter.text = "E para entrar";
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("saiu da area de entrada");
        textEnter.gameObject.SetActive(false);
        onEnterArea = false;
    }
}