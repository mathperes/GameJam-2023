using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    private TrashSettings trashSet;

    public Gradient gradient;

    public Slider sleepSlider;
    public Image fillSleep;
    [SerializeField] private float sleepTimer;

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

    public SpriteRenderer terraNormal;
    public SpriteRenderer terra1;
    public SpriteRenderer terra2;
    public SpriteRenderer terra3;
    public SpriteRenderer terraSeca;
    public SpriteRenderer terraSuja;


    public float timeSleep;
    public float timeHungry;
    public float timeOxigen;
    public float timeTrash;
    public float timePlant;

    // Start is called before the first frame update
    void Start()
    {
        trashSet = GameObject.Find("AreaLixo").GetComponent<TrashSettings>();

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
        SleepTimer();
        HungryTimer();
        PlantTimer();

        if (plantSlider.value <= 0)
        {
            OxigenTimer(1);
        }
        else
        {
            OxigenTimer(-1);
        }

        if (trashSet.trashAmount >= 1)
        {
            TrashTimer(1);
        }
        else
        {
            TrashTimer(-1);
        }
    }

    void SetEarthSprite(SpriteRenderer sprite)
    {
        terraNormal.gameObject.SetActive(false);
        terra1.gameObject.SetActive(false);
        terra2.gameObject.SetActive(false);
        terra3.gameObject.SetActive(false);
        terraSeca.gameObject.SetActive(false);
        terraSuja.gameObject.SetActive(false);

        sprite.gameObject.SetActive(true);
    }

    public void SleepTimer()
    {
        timeSleep -= Time.deltaTime;
        sleepSlider.value = timeSleep;
        fillSleep.color = gradient.Evaluate(sleepSlider.normalizedValue);

        if (timeSleep <= 0)
        {
            SetEarthSprite(terraSeca);
        }
    }

    public void HungryTimer()
    {
        timeHungry -= Time.deltaTime;
        hungrySlider.value = timeHungry;
        fillHungry.color = gradient.Evaluate(hungrySlider.normalizedValue);

        if (timeHungry <= 0)
        {
            SetEarthSprite(terraSeca);
        }
    }

    public void OxigenTimer(int timeAdd)
    {
        timeOxigen -= Time.deltaTime * timeAdd;
        oxigenSlider.value = timeOxigen;
        Debug.Log(timeOxigen);
        fillOxigen.color = gradient.Evaluate(oxigenSlider.normalizedValue);

        if (timeOxigen >= oxigenSlider.maxValue)
        {
            timeOxigen = oxigenSlider.maxValue;
        }

        if (timeOxigen <= 0)
        {
            SetEarthSprite(terraSeca);
        }
    }

    public void TrashTimer(int timeAdd)
    {
        timeTrash -= Time.deltaTime * timeAdd;
        trashSlider.value = timeTrash;
        fillTrash.color = gradient.Evaluate(trashSlider.normalizedValue);

        if (timeTrash >= trashSlider.maxValue)
        {
            timeTrash = trashSlider.maxValue;
        }

        if (timeTrash <= 0)
        {
            SetEarthSprite(terraSuja);
        }
    }

    public void PlantTimer()
    {
        timePlant -= Time.deltaTime;
        plantSlider.value = timePlant;
        fillPlant.color = gradient.Evaluate(plantSlider.normalizedValue);

        if (timePlant <= 0)
        {
            timePlant = 0;
        }

        if (timePlant <= 0)
        {
            SetEarthSprite(terraSeca);
        }
    }
}
