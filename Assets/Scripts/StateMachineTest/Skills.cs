﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : Action
{
    SMDialogueTrigger error;
    static Dictionary<string, (int, int, int)> skills = new Dictionary<string, (int, int, int)>
    {
        { "aggravate", (3, -1, 0) },
        { "offend", (4, -2, -1) }
    };

    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<SMPlayerStats>();
        enemy = GameObject.Find("NPC").GetComponent<SMNPCEntity>();
        error = GameObject.Find("Attack 1").GetComponent<SMDialogueTrigger>();
    }
    
    public override void Learn(string name, int anxiety, int will, int enemyDamage)
    {
        skills.Add(name, (anxiety, will, enemyDamage));
    }

    public override (int, int, int) Use(string moveName)
    {
        player.adjustAnxiety(skills[moveName].Item1);
        if (player.adjustWill(skills[moveName].Item2) < 0)
        {
            string[] msg = new string[] { "You don't have enough Will!" };
            error.TriggerDialogue(new Dialogue("", msg));
            player.switchState(Transitions.Command.waitForPlayer);
            return (0, 0, 0);
        }
        enemy.adjustHealth(skills[moveName].Item3);
        return skills[moveName];
    }

    public static int GetSize()
    {
        return skills.Count;
    }
}
