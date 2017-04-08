using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillEngine : MonoBehaviour
{
    private int playerCurrentLevel;
    public int currentLevel
    {
        get
        {
            return playerCurrentLevel;
        }
    }
    public int playerMaxLevel;
    public int playerStartLevel;

    public string[] skillList;

    private List<Skill> skills = new List<Skill>();

    public void plyerLevelUp()
    {
        if (playerCurrentLevel < playerMaxLevel)
            playerCurrentLevel++;
    }

    private void PopulateSkills()
    {
        foreach(string skillName in skillList)
        {
            skills.Add(new Skill(skillName, 5));
        }
    }

    private void Start()
    {
        PopulateSkills();
        DebugCurrentSkillStatus();
       
    }

    private void DebugCurrentSkillStatus()
    {
        foreach (var skill in skills)
        {
            Debug.Log("Skills = " + skill.skillName + " Maxlevel = " + skill.skillMaxLevel + " currentLevel = " + skill.currentLevel);
        }
    }
}