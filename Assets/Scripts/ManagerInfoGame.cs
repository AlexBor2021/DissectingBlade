using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerInfoGame 
{
    public class LevelInfo
    {
        public static string CountStarsForLevel = "CountStarsForLevel";
        public static string RevardForLevel = "RevardForLevel";
        public static string IScompliteLevel = "IScomplitelevel";
    }
    
    public static void SaveInfoLevel(int currentLevel, int revard, int countStars, int complitelevel)
    {
        //Debug.Log(currentLevel);
        //Debug.Log(revard);
        //Debug.Log(countStars);

        PlayerPrefs.SetInt(LevelInfo.CountStarsForLevel + currentLevel, countStars);
        PlayerPrefs.SetInt(LevelInfo.RevardForLevel + currentLevel, revard);
        PlayerPrefs.SetInt(LevelInfo.IScompliteLevel + currentLevel, complitelevel);
    }
}
