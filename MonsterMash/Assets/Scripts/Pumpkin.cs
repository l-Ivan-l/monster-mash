using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : Vegetable
{
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 3;
        givesFuel = true;
        fuelAmount = 7f;
    }
}
