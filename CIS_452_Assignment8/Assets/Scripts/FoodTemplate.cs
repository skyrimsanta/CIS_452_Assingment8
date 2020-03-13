using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
     * (Levi Schoof)
     * (FoodTemplate)
     * (Assignment8)
     * (The Template abstract class that handles all of the steps of creating food)
*/

public abstract class FoodTemplate : MonoBehaviour
{
    [HideInInspector] public bool withDrink;
    protected Vector3 platePos = new Vector3(-1, 2.8f, 0);
    protected Vector3 mainPos = new Vector3(-1, 2.9f, 0);

    protected Vector3 drinkPos = new Vector3(1, 2.8f, 0);

    public GameObject plate;
    public GameObject item;
    public GameObject drink;

    private float timeBetweenSteps = .35f;

    CustomerOrder customer;

    [HideInInspector] public GameObject itemObject;
    [HideInInspector] public GameObject drinkObject;
    private GameObject thisPlate;

    private void Start()
    {
        itemObject = null;
        drinkObject = null;
        customer = FindObjectOfType<CustomerOrder>();
        StartCoroutine("Order");
    }

    private void PlacePlate()
    {
        thisPlate = Instantiate(plate, null);
        thisPlate.transform.position = platePos;
        thisPlate.transform.localScale = new Vector3(2, 2, 2);
    }

    public abstract void PlaceSide();

    public void PlaceDrink()
    {
        drinkObject = Instantiate(drink, null);
        drinkObject.transform.position = drinkPos;
        drinkObject.transform.localScale = new Vector3(2, 2, 2);
    }

    public virtual bool WithDrink() { return withDrink; }

    IEnumerator Order()
    {
        PlacePlate();
        yield return new WaitForSeconds(timeBetweenSteps);

        PlaceSide();
        yield return new WaitForSeconds(timeBetweenSteps);

        if (WithDrink()) {PlaceDrink();}
        yield return new WaitForSeconds(timeBetweenSteps);

        customer.CompareOrder();
        yield return new WaitForSeconds(timeBetweenSteps);

        Destroy(itemObject.gameObject);
        if (drinkObject)
        {
            Destroy(drinkObject.gameObject);
        }
        Destroy(thisPlate.gameObject);

        Destroy(this.gameObject);

    }



}
