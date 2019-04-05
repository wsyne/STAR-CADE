using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop01Access : MonoBehaviour
{

    public GameObject ShopIventory;
    public GameObject Item01Text;
    public GameObject Item02Text;
    public GameObject Item03Text;
    public GameObject Item04Text;
    public GameObject ItemCompletion;
    public GameObject CompleteText;

    public GameObject Item01PriceBox;
    public GameObject Item02PriceBox;
    public GameObject Item03PriceBox;
    public GameObject Item04PriceBox;

    public int ItemPurchaseNumber;
    public GameObject NotEnough;

    void OnTriggerEnter()
    {
        ShopIventory.SetActive(true);
        //  Screen.LockCursor = false;
        Cursor.lockState = CursorLockMode.None;
        GameShop_Script.ShopNumber = 1;

        Item01Text.GetComponent<Text>().text = " " + GameShop_Script.Item01 + " ";
        Item02Text.GetComponent<Text>().text = " " + GameShop_Script.Item02 + " ";
        Item03Text.GetComponent<Text>().text = " " + GameShop_Script.Item03 + " ";
        Item04Text.GetComponent<Text>().text = " " + GameShop_Script.Item04 + " ";

        Item01PriceBox.GetComponent<Text>().text = "Price: " + GameShop_Script.Item01Price;
        Item02PriceBox.GetComponent<Text>().text = "Price: " + GameShop_Script.Item02Price;
        Item03PriceBox.GetComponent<Text>().text = "Price: " + GameShop_Script.Item03Price;
        Item04PriceBox.GetComponent<Text>().text = "Price: " + GameShop_Script.Item04Price;
    }

    public void Item01()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<Text>().text = "Are you sure you want to buy " + GameShop_Script.Item01 + " ?";
        ItemPurchaseNumber = 1; 
    }

    public void Item02()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<Text>().text = "Are you sure you want to buy " + GameShop_Script.Item02 + " ?";
        ItemPurchaseNumber = 2;
    }

    public void Item03()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<Text>().text = "Are you sure you want to buy " + GameShop_Script.Item03 + " ?";
        ItemPurchaseNumber = 3;
    }

    public void Item04()
    {
        ItemCompletion.SetActive(true);
        CompleteText.GetComponent<Text>().text = "Are you sure you want to buy " + GameShop_Script.Item04 + " ?";
        ItemPurchaseNumber = 4;
    }

    public void CancelTransaction ()
    {
        ItemCompletion.SetActive(false);
        ItemPurchaseNumber = 0;
        NotEnough.SetActive(false);
    }

    public void CompleteTransaction()
    {
        if (ItemPurchaseNumber == 1)
        {
            if (TicketWallet.CurrentTickets >= GameShop_Script.Item01Price)
            {
                TicketWallet.CurrentTickets -= GameShop_Script.Item01Price;
                ItemCompletion.SetActive(false);
            }

            else
            {
                NotEnough.SetActive(true);
            }
        }

        if (ItemPurchaseNumber == 2)
        {
            if (TicketWallet.CurrentTickets >= GameShop_Script.Item02Price)
            {
                TicketWallet.CurrentTickets -= GameShop_Script.Item02Price;
                ItemCompletion.SetActive(false);
            }

            else
            {
                NotEnough.SetActive(true);
            }
        }

        if (ItemPurchaseNumber == 3)
        {
            if (TicketWallet.CurrentTickets >= GameShop_Script.Item03Price)
            {
                TicketWallet.CurrentTickets -= GameShop_Script.Item03Price;
                ItemCompletion.SetActive(false);
            }

            else
            {
                NotEnough.SetActive(true);
            }
        }

        if (ItemPurchaseNumber == 4)
        {
            if (TicketWallet.CurrentTickets >= GameShop_Script.Item04Price)
            {
                TicketWallet.CurrentTickets -= GameShop_Script.Item04Price;
                ItemCompletion.SetActive(false);
            }

            else
            {
                NotEnough.SetActive(true);
            }
        }
    }
}
