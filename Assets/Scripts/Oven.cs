using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public bool p_isCooking { get; private set; } //encapsulation
    public bool p_isDone { get; private set; } //encapsulation
    private float p_cookingTime = 5f;
    public int score; // ?
    [SerializeField] private ParticleSystem p_particleSystem;

    public virtual void OnMouseDown()
    {
        if (!p_isCooking && !p_isDone)
        {
            p_isCooking = true;
            //color = red;
            Invoke("Cooking", p_cookingTime);
        }
        else if (p_isDone)
        {
            //får ut en paj
            p_isDone = false;
            //AddScore(p_particleSystem);
        }
    }

    public virtual void Cooking()
    {
        //color = green;
        p_isCooking = false;
        p_isDone = true;
    }

    //public virtual void AddScore(ParticleSystem particleSystem)
    //{
    //    particleSystem.Play();
    //    score += 10;
    //}
}
