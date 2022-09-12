using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    private Image barImage;
    private Energy energy;
    public float energyUsageRate;
    public GameOverLabel gameOverLabel;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        energy = new Energy(energyUsageRate);
    }

    public void UseEnergy()
    {
        energy.Update();
        barImage.fillAmount = energy.GetEnergy() * 0.01f;

        if (energy.GetEnergy() <= 0)
        {
            gameOverLabel.showLabel();
        }
    }
}

public class Energy
{
    public const float ENERGY_MAX = 100;

    private float energyAmount;
    private float energyUseOnMovement;

    public Energy(float energyUsageRate)
    {
        energyAmount = ENERGY_MAX;
        energyUseOnMovement = energyUsageRate;
    }

    public void Update()
    {
        energyAmount -= energyUseOnMovement;

    }

    public float GetEnergy()
    {
        return (float)energyAmount;
    }
}
