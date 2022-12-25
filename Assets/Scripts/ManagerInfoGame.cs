using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerInfoGame 
{
    public static int CountStarsForLevel;
    public static int CurrentLevel;
    public static int CountCoinPlayer;

    public static bool IsLevelCompled;

    public static void ZeroInfo()
    {
        CountStarsForLevel = 0;
        CurrentLevel = 0;
        IsLevelCompled = false;
    }
}
