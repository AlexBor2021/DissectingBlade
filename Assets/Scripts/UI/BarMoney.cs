using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Update()
    {
        _coinText.text = PlayerPrefs.GetInt(ManagerInfoGame.PlayerInfo.Walett).ToString();
    }
}
