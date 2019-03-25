﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public Towersona towersonaToBuild;

    private Button button;
    private TextMeshProUGUI costText;


    private void Awake()
    {            
        button = GetComponent<Button>();     
    }

    private void Start()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = towersonaToBuild.costs[0].ToString() + '$';

    }

    private void Update()
    {
        if(PlayerStats.Instance.money < towersonaToBuild.costs[0] && DebuggingOptions.Instance.useMoney)
        {
            button.interactable = false;           
        }
        else
        {
            button.interactable = true;          
        }      
    }

    public void SelectTowersona()
    {
        BuildManager.Instance.SelectTowersonaToBuild(towersonaToBuild);
    }
}
