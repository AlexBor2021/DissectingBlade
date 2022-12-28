using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelRevard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(int revard)
    {
        _text.text = revard.ToString();
        gameObject.SetActive(true);
    }
}
