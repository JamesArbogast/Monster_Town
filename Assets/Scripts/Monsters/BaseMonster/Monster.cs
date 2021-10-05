using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    private string name;
    private string description;
    public int tier;
    public bool nest;
    public bool minions;
    public int strength;
    public int speed;
    public int stealth;
    public int range;

    public Monster(string name, string description, int tier, bool nest, bool minions,
        int strength, int speed, int stealth, int range)
    {
        name = this.name;
        description = this.description;
        tier = this.tier;
        nest = this.nest;
        minions = this.minions;
        strength = this.strength;
        speed = this.speed;
        stealth = this.stealth;
        range = this.range;
    }
}
