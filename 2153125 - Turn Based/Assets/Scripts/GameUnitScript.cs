using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitScript : MonoBehaviour
{
    public string UnitName;
    public int DamageOutput;
    public int MagicDamageOutput;
    public int MaximumHealth;
    public int CurrentHealth;
    public int LimitBreakDamageOutput;
    public int LimitBreakDamageThreshold;
    public int MP;
    public int LBPoint = 1;
    public ParticleSystem DamagePart;
    public ParticleSystem MagicPart;
    public ParticleSystem LimitBREAKPart;
    public bool Damage(int Damnage)
    {
        CurrentHealth -= Damnage;

        if (CurrentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool MagicDamage(int MagDam)
    {
        CurrentHealth -= MagDam;

        if (CurrentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LimitBreakDamage(int LimitBreakDam)
    {
        CurrentHealth -= LimitBreakDam;

        if(CurrentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
