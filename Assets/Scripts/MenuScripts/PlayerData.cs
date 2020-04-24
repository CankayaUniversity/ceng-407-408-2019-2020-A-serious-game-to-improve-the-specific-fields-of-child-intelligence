﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int playercurrency;
    public int playermascotindex;
    public bool[] player_unlocked_outfit = new bool[] { false, false, false};

    public PlayerData(AllVar allvar)
    {
        playercurrency = allvar.saved_totalgold;
        playermascotindex = allvar.saved_mascotindex;
        for (int i = 0; i < 3; i++)
        {
            player_unlocked_outfit[i] = allvar.saved_unlocked_clothe[i];
        }

    }
}