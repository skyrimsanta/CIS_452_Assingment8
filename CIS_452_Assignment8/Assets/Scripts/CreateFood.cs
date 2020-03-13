using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
     * (Levi Schoof)
     * (Create Food)
     * (Assignment8)
     * (Handles all the behaviors of the buttons and UI that relate to the food classes)
*/

public class CreateFood : MonoBehaviour
{
    public Button orderButton;
    public Button[] items;
    public Button[] drinks;
    public enum Item { Donut, Pie, Cookie, notSet };
    [HideInInspector] public Item thisItem;

    public enum Drink { None, Yes, notSet };
    [HideInInspector] public Drink thisDrink;

    public Image itemImage;
    public Image drinkImage;

    public Sprite donut;
    public Sprite cookie;
    public Sprite pie;

    public Sprite drink;
    public Sprite noDrinl;

    public GameObject donutPrefab;
    public GameObject piePrefab;
    public GameObject cookiePrefab;

    private FoodTemplate thisFood;


    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        orderButton.interactable = false;
        thisDrink = Drink.notSet;
        thisItem = Item.notSet;

        itemImage.sprite = null;
        drinkImage.sprite = null;

        foreach(Button b in drinks)
        {
            b.interactable = true;
        }

        foreach (Button b in items)
        {
            b.interactable = true;
        }

        thisFood = null;
    }

    public void SetItem(int item)
    {
        thisItem = (Item)item;

        switch (thisItem)
        {
            case Item.Cookie:
                itemImage.sprite = cookie;
                break;

            case Item.Donut:
                itemImage.sprite = donut;
                break;

            case Item.Pie:
                itemImage.sprite = pie;
                break;
        }

        IsOrderReady();
    }

    public void SetDrink(int withDrink)
    {
        thisDrink = (Drink)withDrink;
        switch (thisDrink)
        {
            case Drink.Yes:
                drinkImage.sprite = drink;
                break;

            case Drink.None:
                drinkImage.sprite = noDrinl;
                break;
        }

        IsOrderReady();
    }

    private void IsOrderReady()
    {
        if(thisDrink != Drink.notSet & thisItem != Item.notSet)
        {
            orderButton.interactable = true;
        }
    }

    public void Order()
    {
        orderButton.interactable = false;

        foreach (Button b in drinks)
        {
            b.interactable = false;
        }

        foreach (Button b in items)
        {
            b.interactable = false;
        }

        switch (thisItem)
        {
            case Item.Cookie:
                thisFood = Instantiate(cookiePrefab).GetComponent<FoodTemplate>();
                break;

            case Item.Donut:
                thisFood = Instantiate(donutPrefab).GetComponent<FoodTemplate>();
                break;

            case Item.Pie:
                thisFood = Instantiate(piePrefab).GetComponent<FoodTemplate>();
                break;
        }

        switch (thisDrink)
        {
            case Drink.Yes:
                thisFood.withDrink = true;
                break;

            case Drink.None:
                thisFood.withDrink = false;
                break;
        }
    }
}
