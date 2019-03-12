﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedTowersonaView : MonoBehaviour
{
    public Slider slider;
    public GameObject overHappiness;
    public Transform[] shitPositions;

    [HideInInspector]
    public Towersona towersona;
    [HideInInspector]
    public TowersonaAnimation towersonaAnim;
    [HideInInspector]
    public TowersonaNeeds towersonaNeeds;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    public GameObject SpawnTowersonaNeedsModel(GameObject towersonaModel, Towersona towersona)
    {
        /*
         * Código temporal (espero), simplemente va asignando las variables necesarias que necesitan los distintos scripts que hizo Aitor
         * para poder distintos modelos dentro de un DetailedTowersonaView
        */       

        GameObject model = Instantiate(towersonaModel);
        model.transform.SetParent(transform, false);

        this.towersona = towersona;

        TowersonaNeeds needs = model.GetComponent<TowersonaNeeds>();        

        needs.happinessSlider = slider;
        needs.overHappiness = overHappiness;

        towersonaNeeds = needs;
        towersonaAnim = model.GetComponent<TowersonaAnimation>();
        towersonaAnim.lookAway.camera = cam;

        ShitNeed shitNeed = model.GetComponent<ShitNeed>();
        shitNeed.shitSpawnPositions = shitPositions;

        return model;
    }  

    public void LevelUp()
    {
        towersona.LevelUp();
    }
}