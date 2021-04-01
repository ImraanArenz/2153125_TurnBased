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
    public ParticleSystem DamagePart;
    public ParticleSystem MagicPart;

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
}
