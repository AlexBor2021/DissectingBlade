using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private ListWeaponsPlayer _weaponPlayer;
    [SerializeField] private int _price;
    [SerializeField] private int _indexWepon;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private ManagerButtonSet _managerButtonSet;
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _buttonSet;

    private bool _isSetWeapon;
    private bool _isBuy;

    private void OnEnable()
    {
        _priceText.text = _price.ToString();
        LoadInfo();
    }

    public void BuyWeapon()
    {
        if (_price <= PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.Walett))
        {
            _isBuy = true;
            
            ManagerInfoGame.PayCoinFromWalletPlayer(_price);
            
            ManagerInfoGame.SaveInfoWeaponShop(_indexWepon, _isBuy, _isSetWeapon);
            
            _buttonBuy.SetActive(false); 
            
            _buttonSet.SetActive(true);
        }
    }

    public void SetWeapon()
    {
        _isSetWeapon = true;
        
        PlayerPrefs.SetInt(ManagerInfoGame.PlayerInfo.CurrentWeapon, _indexWepon);
       
        ManagerInfoGame.SaveInfoWeaponShop(_indexWepon, _isBuy, _isSetWeapon);
        
        _buttonSet.SetActive(false);
       
        _weaponPlayer.SetWeapon();

        _managerButtonSet.LoadInfo();
    }

    public void LoadInfo()
    {
        if (PlayerPrefs.GetInt(ManagerInfoGame.WeaponShopInfo.IsBuyWeapon + _indexWepon) > 0)
        {
            _isBuy = true;
            _buttonBuy.SetActive(false);

            if (PlayerPrefs.GetInt(ManagerInfoGame.WeaponShopInfo.IsSetWeapon + _indexWepon) > 0)
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
        else
        {
            _isBuy = false;
            _buttonBuy.SetActive(true);
        }
        
    }
}
