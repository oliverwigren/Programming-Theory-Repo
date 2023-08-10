using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Oven : MonoBehaviour
{
    public bool p_isCooking { get; private set; } //ENCAPSULATION
    public bool p_isDone { get; private set; } //ENCAPSULATION
    private float p_cookingTime = 5f;
    private int p_points = 5;

    public int score { get; protected set; } //ENCAPSULATION
    [SerializeField] private ParticleSystem p_particleSystem;

    protected Material defaultMaterial;
    protected Material greenMaterial;
    protected Material redMaterial;


    private void Start()
    {
        SetColors();
        //SetTitle();
    }

    private void SetColors() //ABSTRACTION
    {
        defaultMaterial = Resources.Load("Material/default", typeof(Material)) as Material;
        greenMaterial = Resources.Load("Material/Green", typeof(Material)) as Material;
        redMaterial = Resources.Load("Material/Red", typeof(Material)) as Material;
    }

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
            AddScore(p_particleSystem, p_points);
            p_isDone = false;
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    public virtual void FinishCooking() //ABSTRACTION
    {
        gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        p_isCooking = false;
        p_isDone = true;
    }

    public virtual void AddScore(ParticleSystem particleSystem, int points) //ABSTRACTION
    {
        particleSystem.Play();
        score += points;
    }
}
