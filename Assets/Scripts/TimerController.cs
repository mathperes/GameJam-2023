using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public Gradient gradient;

    public Slider sleepSlider;
    public Image fillSleep;
    [SerializeField]private float sleepTimer;

    public Slider hungrySlider;
    public Image fillHungry;
    [SerializeField] private float hungryTimer;

    public Slider oxigenSlider;
    public Image fillOxigen;
    [SerializeField] private float oxigenTimer;

    public Slider trashSlider;
    public Image fillTrash;
    [SerializeField] private float trashTimer;

    public Slider plantSlider;
    public Image fillPlant;
    [SerializeField] private float plantTimer;

    // Start is called before the first frame update
    void Start()
    {
        sleepSlider.maxValue = sleepTimer;
        sleepSlider.value = sleepTimer;

        hungrySlider.maxValue = hungryTimer;
        hungrySlider.value = hungryTimer;

        oxigenSlider.maxValue = oxigenTimer;
        oxigenSlider.value = oxigenTimer;

        trashSlider.maxValue = trashTimer;
        trashSlider.value = trashTimer;

        plantSlider.maxValue = plantTimer;
        plantSlider.value = plantTimer;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSleep = sleepTimer - Time.time;
        sleepSlider.value = timeSleep;
        fillSleep.color = gradient.Evaluate(sleepSlider.normalizedValue);

        float timeHungry = hungryTimer - Time.time;
        hungrySlider.value = timeHungry;
        fillHungry.color = gradient.Evaluate(hungrySlider.normalizedValue);

        float timeOxigen = oxigenTimer - Time.time;
        oxigenSlider.value = timeOxigen;
        fillOxigen.color = gradient.Evaluate(oxigenSlider.normalizedValue);

        float timeTrash = trashTimer - Time.time;
        trashSlider.value = timeTrash;
        fillTrash.color = gradient.Evaluate(trashSlider.normalizedValue);

        float timePlant = plantTimer - Time.time;
        plantSlider.value = timePlant;
        fillPlant.color = gradient.Evaluate(plantSlider.normalizedValue);
    }
    
}
