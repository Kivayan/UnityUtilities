using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    private int skillCurrentLevel;
    public int currentLevel
    {
        get
        {
            return skillCurrentLevel;
        }
    }
    public int skillMaxLevel;
    public int skillStartLevel;

    public string skillName;

    public void LevelUp()
    {
        if (skillCurrentLevel < skillMaxLevel)
            skillCurrentLevel++;
    }

    public Skill(string name)
    {
        skillName = name;
        skillStartLevel = 0;
        skillMaxLevel = 10;
        skillCurrentLevel = skillStartLevel;
    }

    public Skill(string name, int maxLevel)
    {
        skillName = name;
        skillStartLevel = 0;
        skillMaxLevel = maxLevel;
        skillCurrentLevel = skillStartLevel;
    }

}
