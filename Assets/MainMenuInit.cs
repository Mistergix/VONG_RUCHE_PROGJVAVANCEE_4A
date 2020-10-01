﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInit : MonoBehaviour
{
    [SerializeField]
    private PlayerData nullData;

    [SerializeField]
    private List<Player> players;

    private void Start()
    {
        foreach (var player in players)
        {
            player.Init(nullData);
            player.gameObject.SetActive(true);
        }
    }
}
