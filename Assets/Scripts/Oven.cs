using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Oven : MonoBehaviour
{
    public bool p_isCooking { get; private set; } //encapsulation
    public bool p_isDone { get; private set; } //encapsulation
    private float p_cookingTime = 5f;
    public int score; // ?
    [SerializeField] private ParticleSystem p_particleSystem;

    [SerializeField] protected Material defaultMaterial;
    [SerializeField] protected Material greenMaterial;
    [SerializeField] protected Material redMaterial;

    //private void Start()
    //{
    //    SetUp();
    //}

    //public virtual void SetUp()
    //{
    //    greenMaterial = Resources.Load("Material/Green.mat", typeof(Material)) as Material;
    //    redMaterial = Resources.Load("Material/Red.mat", typeof(Material)) as Material;
    //}

    public virtual void OnMouseDown()
    {
        if (!p_isCooking && !p_isDone)
        {
            p_isCooking = true;
            gameObject.GetComponent<MeshRenderer>().material = redMaterial;
            Invoke("FinishCooking", p_cookingTime);
        }
        else if (p_isDone)
        {
            //får ut en paj
            p_isDone = false;
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    public virtual void FinishCooking()
    {
        gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        p_isCooking = false;
        p_isDone = true;
    }

    //public virtual void AddScore(ParticleSystem particleSystem) 
    //{
    //    particleSystem.Play();
    //    score += 10;
    //}
}
