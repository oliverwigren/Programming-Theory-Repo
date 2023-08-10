using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterOven : Oven //INHERITANCE
{
    //The better oven has shorter cooking time and generates more points.

    public bool s_isCooking { get; private set; } //ENCAPSULATION
    public bool s_isDone { get; private set; } //ENCAPSULATION
    private int points = 10;
    private float s_cookingTime = 3f;

    [SerializeField] private ParticleSystem s_particleSystem;

    public override void OnMouseDown() //POLYMORPHISM
    {
        if (!s_isCooking && !s_isDone)
        {
            s_isCooking = true;
            gameObject.GetComponent<MeshRenderer>().material = redMaterial;
            Invoke("FinishCooking", s_cookingTime);
        }
        else if (s_isDone)
        {
            GetComponentInParent<Oven>().AddScore(s_particleSystem, points);
            s_isDone = false;
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    public override void FinishCooking() //POLYMORPHISM
    {
        gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        s_isCooking = false;
        s_isDone = true;
    }
}
