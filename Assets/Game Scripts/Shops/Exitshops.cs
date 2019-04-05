using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitshops : MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject NotEnough;

    public void ExitShopMode ()
    {
        ShopPanel.SetActive(false);
        NotEnough.SetActive(false);

    }



}
