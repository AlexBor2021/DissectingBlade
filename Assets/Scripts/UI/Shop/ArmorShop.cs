using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmorShop : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _indexArmor;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _buttonSet;

    private bool _isBuy;
    private bool _isSetArmor;

    private void OnEnable()
    {
        LoadInfo();
    }

    public void BuyArmor()
    {
        if (_price < PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.Walett))
        {
            ManagerInfoGame.PayCoinFromWalletPlayer(_price);
            _buttonBuy.SetActive(false);
            _isBuy = true;
            ManagerInfoGame.SaveInfoArmorShop(_indexArmor, _isBuy, _isSetArmor);
        }
    }

    public void SetArmor()
    {
        _isSetArmor = true;
        PlayerPrefs.SetInt(ManagerInfoGame.PlayerInfo.CurrentArmor, _indexArmor);
        ManagerInfoGame.SaveInfoArmorShop(_indexArmor, _isBuy, _isSetArmor);
        _buttonSet.SetActive(false);
    }

    private void LoadInfo()
    {
        if (PlayerPrefs.GetInt(ManagerInfoGame.ArmorShopInfo.IsBuyArmor) > 0)
        {
            _isBuy = true;
            _buttonBuy.SetActive(false);
        }
        else
        {
            _isBuy = false;
            _buttonBuy.SetActive(true);
        }
        if (PlayerPrefs.GetInt(ManagerInfoGame.ArmorShopInfo.IsSetArmor) > 0)
        {
            _isSetArmor = true;
            _buttonSet.SetActive(false);
        }
        else
        {
            _isSetArmor = false;
            _buttonSet.SetActive(true);
        }
    }
}
