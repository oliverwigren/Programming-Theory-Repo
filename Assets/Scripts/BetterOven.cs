using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterOven : Oven //INHERITANCE
{
    public bool s_isCooking { get; private set; } //encapsulation
    public bool s_isDone { get; private set; } //encapsulation
    private float s_cookingTime = 3f;
    [SerializeField] private ParticleSystem s_particleSystem;

    public override void OnMouseDown()
    {
        if (!s_isCooking && !s_isDone)
        {
            s_isCooking = true;
            //color = red;
            Invoke("Cooking", s_cookingTime);
        }
        else if (p_isDone)
        {
            //får ut en paj
            s_isDone = false;
        }
    }

    public override void Cooking()
    {
        //color = green;
        s_isCooking = false;
        s_isDone = true;
    }

    //public override void AddScore(ParticleSystem particleSystem)
    //{
    //    base.AddScore(s_particleSystem);
    //}
}
