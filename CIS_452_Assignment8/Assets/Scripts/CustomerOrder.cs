using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
     * (Levi Schoof)
     * (CustomerOrder)
     * (Assignment8)
     * (Handles the gameplay of the game and the customer orders)
*/
public class CustomerOrder : MonoBehaviour
{
    public Image itemImage;
    public Image drinkImage;

    public Sprite donut;
    public Sprite cookie;
    public Sprite pie;

    public Sprite drink;
    public Sprite noDrink;

    public CreateFood.Item thisItem;
    public CreateFood.Drink thisDrink;

    CreateFood createFood;

    int temp;

    public Text goldCount;
    public int gold;

    public Text timerText;
    private float startTime = 50;
    private float timeLeft;

    [HideInInspector] public float goal = 10;

    public GameObject htp;
    public GameObject end;
    public Text endText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        htp.SetActive(true);
        end.SetActive(false);
        gold = 0;
        goldCount.text = "Money <color=yellow>$ " + gold + "</color>";
        createFood = FindObjectOfType<CreateFood>();
        NewOrder();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenHTP();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        timerText.text = "Time Left: " + (int)(startTime - (timeLeft += Time.deltaTime));

        if(timeLeft >= startTime )
        {
            if(Time.timeScale > 0)
            {
                EndGame();
            }
        }
    }

    private void OpenHTP()
    {
        if (htp.activeSelf)
        {
            htp.SetActive(false);
            Time.timeScale = 1;
        }

        else
        {
            htp.SetActive(true);
            Time.timeScale = 1;
        }
    }

    private void NewOrder()
    {
        temp = Random.Range(0, 3);
        switch (temp)
        {
            case 0:
                itemImage.sprite = donut;
                thisItem = CreateFood.Item.Donut;
                break;
            case 1:
                itemImage.sprite = pie;
                thisItem = CreateFood.Item.Pie;
                break;
            case 2:
                itemImage.sprite = cookie;
                thisItem = CreateFood.Item.Cookie;
                break;
        }

        temp = Random.Range(0, 2);

        switch (temp)
        {
            case 0:
                drinkImage.sprite = drink;
                thisDrink = CreateFood.Drink.Yes;
                break;
            case 1:
                drinkImage.sprite = noDrink;
                thisDrink = CreateFood.Drink.None;
                break;
        }
    }

    public void CompareOrder()
    {
        if(createFood.thisDrink == thisDrink & createFood.thisItem == thisItem)
        {
            IncreaseMoney(1);
        }

        else
        {
            IncreaseMoney(-1);
        }

        Reset();
    }

    private void Reset()
    {
        NewOrder();
        createFood.Reset();

    }

    public void IncreaseMoney(int change)
    {
        gold += change;
        if(gold >= 0 & gold < goal)
        {
            goldCount.text = "Money <color=yellow>$ " + gold + "</color>";
        }

        else if(gold >= goal)
        {
            goldCount.text = "Money <color=green>$ " + gold + "</color>";
        }

        else
        {
            goldCount.text = "Money <color=red>$" + gold + "</color>";
        }
    }

    private void EndGame()
    {
        end.SetActive(true);
        Time.timeScale = 0;
        if (gold >= goal)
        {
            endText.text = "You Won";
        }

        else
        {
            endText.text = "Oh No You Lost";
        }
    }
}
