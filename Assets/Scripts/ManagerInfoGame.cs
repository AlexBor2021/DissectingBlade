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
    public class PlayerInfo
    {
        public static string Walett = "Walett";
        public static string CurrentWeapon = "CurrentWeapon";
        public static string CurrentArmor = "CurrentArmor";
    }
    public class WeaponShopInfo
    {
        public static string IsBuyWeapon = "IsBuyWeapon";
        public static string IsSetWeapon = "IsSetWeapon";
    }
    public class ArmorShopInfo
    {
        public static string IsBuyArmor = "IsBuyArmor";
        public static string IsSetArmor = "IsSetArmor";
    }
    public static void SaveInfoArmorShop(int indexArmor, bool isBuy, bool isSet)
    {
        int isBuyInt;
        int isSetInt;

        if (isBuy)
            isBuyInt = 1;
        else
            isBuyInt = 0;

        if (isSet)
            isSetInt = 1;
        else
            isSetInt = 0;

        PlayerPrefs.SetInt(ArmorShopInfo.IsBuyArmor + indexArmor, isBuyInt);
        PlayerPrefs.SetInt(ArmorShopInfo.IsSetArmor + indexArmor, isSetInt);
    }
    public static void SaveInfoWeaponShop(int indexWeapon, bool isBuy, bool isSet)
    {
        int isBuyInt;
        int isSetInt;

        if (isBuy)
            isBuyInt = 1;
        else
            isBuyInt = 0;

        if (isSet)
            isSetInt = 1;
        else
            isSetInt = 0;

        PlayerPrefs.SetInt(WeaponShopInfo.IsBuyWeapon + indexWeapon, isBuyInt);
        PlayerPrefs.SetInt(WeaponShopInfo.IsSetWeapon + indexWeapon, isSetInt);
    }

    public static void SaveInfoLevel(int currentLevel, int countStars, int complitelevel)
    {
        PlayerPrefs.SetInt(LevelInfo.CountStarsForLevel + currentLevel, countStars);
        PlayerPrefs.SetInt(LevelInfo.IScompliteLevel + currentLevel, complitelevel);
    }

    public static void AddCoinInWalletPlayer(int coinAdd)
    {
        int coinBefore = PlayerPrefs.GetInt(PlayerInfo.Walett);
        coinBefore += coinAdd;
        PlayerPrefs.SetInt(PlayerInfo.Walett, coinBefore);
    }
    public static void PayCoinFromWalletPlayer(int coinPay)
    {
        int coinBefore = PlayerPrefs.GetInt(PlayerInfo.Walett);
        coinBefore -= coinPay;
        PlayerPrefs.SetInt(PlayerInfo.Walett, coinBefore);
    }
}
