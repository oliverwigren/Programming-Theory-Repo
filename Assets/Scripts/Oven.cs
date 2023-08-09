using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public bool isCooking { get; private set; } //encapsulation
    public bool isDone { get; private set; } //encapsulation
    private float cookingTime = 5f;

    private void OnMouseDown()
    {
        if (!isCooking && !isDone)
        {
            isCooking = true;
            //color = red;
            Invoke("Cooking", cookingTime);
        }
        else if(isDone)
        {
            //får ut en paj
            isDone = false;
        }
    }

    void Cooking()
    {
        //color = green;
        isDone = true;
    }
}
