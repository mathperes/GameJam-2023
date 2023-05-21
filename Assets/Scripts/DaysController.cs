using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaysController : MonoBehaviour
{
    public TextMeshProUGUI textoDias;
    public TextMeshProUGUI textoMorte;

    private float tempoDia = 0;
    public static int diaAtual = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoDia += Time.deltaTime;
        if (tempoDia >= 60)
        {
            tempoDia = 0;
            diaAtual++;
        }

        textoDias.text = "Dia: " + diaAtual;
        textoMorte.text = "Você perdeu, Oli sobreviveu por " + diaAtual + " dia(s)";
    }
}
