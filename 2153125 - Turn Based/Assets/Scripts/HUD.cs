using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text PlayerName;
    public Slider HP;
    public GameUnitScript PC;


    public void TheHUD(GameUnitScript GameUnit)
    {
        PlayerName.text = GameUnit.UnitName;
        HP.maxValue = GameUnit.MaximumHealth;
        HP.value = GameUnit.CurrentHealth;
    }

    public void PlayerHP(int HealPo)
    {
        HP.value = HealPo;
    }

}
