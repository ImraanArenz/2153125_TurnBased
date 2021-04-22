using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    public Text EnemyName;
    public Slider EnemyHP;


    
    public void TheHUD(GameUnitScript GameUnit)
    {
        EnemyName.text = GameUnit.UnitName;
        EnemyHP.maxValue = GameUnit.MaximumHealth;
        EnemyHP.value = GameUnit.CurrentHealth;
    }

    public void PlayerHP(int HealPo)
    {
        EnemyHP.value = HealPo;
    }

}
