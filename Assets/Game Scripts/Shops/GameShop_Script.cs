using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShop_Script : MonoBehaviour
{
    public static string Item01;
    public static string Item02;
    public static string Item03;
    public static string Item04;
    public static int ShopNumber;

    public static int Item01Price;
    public static int Item02Price;
    public static int Item03Price;
    public static int Item04Price;

    // Update is called once per frame
    void Update ()
    {
		if (ShopNumber == 1)
        {
            Item01 = "lolly";
            Item01Price = 10;

            Item02 = "Mini Basketball";
            Item02Price = 100;

            Item03 = "Rubber Duck";
            Item03Price = 200;

            Item04 = "Teddy Bear";
            Item04Price = 500;

        } 

        if (ShopNumber == 2)
        {
            Item01 = " Mini Football";
            Item02 = " Bunny ";
            Item03 = " Robot ";
            Item04 = " Slinky ";

        }

    }

    
}
