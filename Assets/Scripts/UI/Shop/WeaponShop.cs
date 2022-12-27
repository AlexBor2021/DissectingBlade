using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _indexWepon;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _buttonSet;

    private bool _isBuy;
    private bool _isSetWeapon;

    private void OnEnable()
    {
        _priceText.text = _price.ToString();
        LoadInfo();
    }

    public void BuyWeapon()
    {
        if (_price < PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.Walett))
        {
            ManagerInfoGame.PayCoinFromWalletPlayer(_price);
            _buttonBuy.SetActive(false);
            _isBuy = true;
            ManagerInfoGame.SaveInfoWeaponShop(_indexWepon, _isBuy, _isSetWeapon);
        }
    }

    public void SetWeapon()
    {
        _isSetWeapon = true;
        PlayerPrefs.SetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon, _indexWepon);
        ManagerInfoGame.SaveInfoWeaponShop(_indexWepon, _isBuy, _isSetWeapon);
        _buttonSet.SetActive(false);
    }

    private void LoadInfo()
    {
        if (PlayerPrefs.GetInt(ManagerInfoGame.WeaponShopInfo.IsBuyWeapon) > 0)
        {
            _isBuy = true;
            _buttonBuy.SetActive(false);
        }
        else
        {
            _isBuy = false;
            _buttonBuy.SetActive(true);
        }
        if (PlayerPrefs.GetInt(ManagerInfoGame.WeaponShopInfo.IsSetWeapon) > 0)
        {
            _isSetWeapon = true;
            _buttonSet.SetActive(false);
        }
        else
        {
            _isSetWeapon = false;
            _buttonSet.SetActive(true);
        }
    }
}
