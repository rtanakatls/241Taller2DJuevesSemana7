using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;

    [SerializeField] private TextMeshProUGUI lifeText;

    [SerializeField] private Image lifeBarImage;
    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLifeText(int value)
    {
        lifeText.text = $"Life: {value}";
    }

    public void UpdateLifeBar(float life, float maxLife)
    {
        lifeBarImage.fillAmount = life / maxLife;
    }
}
