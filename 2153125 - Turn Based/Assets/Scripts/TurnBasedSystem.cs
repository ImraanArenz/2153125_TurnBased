using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStateMachine { BeginBattle, PlayerTurn, EnemyTurn, PlayerWin, PlayerLose}
public class TurnBasedSystem : MonoBehaviour
{
    public BattleStateMachine CurrentState;
    public Transform PlayerPos;
    public Transform EnemyPos;
    public GameObject PlayerPrefabObject;
    public GameObject EnemyPrefabObject;
    GameUnitScript PlayerCharUnit;
    GameUnitScript EnemyCharUnit;
    public HUD playerHUD;
    public HUD enemyHUD;
    public Text infoText;

    private void Start()
    {
        CurrentState = BattleStateMachine.BeginBattle;
        StartCoroutine(StartBattle());

    }

    IEnumerator StartBattle()
    {
        GameObject PlayerObj = Instantiate(PlayerPrefabObject, PlayerPos);
        PlayerCharUnit = PlayerObj.GetComponent<GameUnitScript>();

        Instantiate(EnemyPrefabObject, EnemyPos);
        EnemyCharUnit = EnemyPrefabObject.GetComponent<GameUnitScript>();


        playerHUD.TheHUD(PlayerCharUnit);
        enemyHUD.TheHUD(EnemyCharUnit);
        yield return new WaitForSeconds(1.5f);

        CurrentState = BattleStateMachine.PlayerTurn;
        PlayerNoTurn();
    }
    IEnumerator Attack()
    {
        bool Dead = EnemyCharUnit.Damage(PlayerCharUnit.DamageOutput);
        Instantiate(EnemyCharUnit.DamagePart);
        infoText.text = "Dealt Slashing Damage!!!";

        yield return new WaitForSeconds(1f);

        enemyHUD.PlayerHP(EnemyCharUnit.CurrentHealth);

        if (Dead)
        {
            CurrentState = BattleStateMachine.PlayerWin;
            battleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.EnemyTurn;
            StartCoroutine(EnemyNoTurn());
        }
    }

    IEnumerator MagicAttack()
    {
        bool Dead = EnemyCharUnit.MagicDamage(PlayerCharUnit.MagicDamageOutput);
        Instantiate(EnemyCharUnit.MagicPart);
        infoText.text = "Virus corruption damage!!!";

        yield return new WaitForSeconds(3f);

        if (Dead)
        {
            CurrentState = BattleStateMachine.PlayerWin;
            battleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.EnemyTurn;
            StartCoroutine(EnemyNoTurn());
        }
    }

    public void battleOver()
    {
        if (CurrentState == BattleStateMachine.PlayerWin)
        {
            infoText.text = "You Win!";
        }
        else if(CurrentState == BattleStateMachine.PlayerLose)
        {
            infoText.text = "Git gud, SCRUB!";
        }
    }

    IEnumerator EnemyNoTurn()
    {
        infoText.text = EnemyCharUnit.UnitName + " lunges and deals some physical damage!!";
        yield return new WaitForSeconds(2f);

        bool Dead = PlayerCharUnit.Damage(EnemyCharUnit.DamageOutput);

        playerHUD.PlayerHP(PlayerCharUnit.CurrentHealth);
        Instantiate(PlayerCharUnit.DamagePart);
        yield return new WaitForSeconds(2f);

        if (Dead)
        {
            CurrentState = BattleStateMachine.PlayerLose;
            battleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.PlayerTurn;
            PlayerNoTurn();
        }


    }
    void PlayerNoTurn()
    {
        infoText.text = "Select";
    }

    public void AttackButton()
    {
        if (CurrentState != BattleStateMachine.PlayerTurn)
        {
            return;
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    public void MagicButton()
    {
        if (CurrentState != BattleStateMachine.PlayerTurn)
        {
            return;
        }
        else
        {
            StartCoroutine(MagicAttack());
        }
    }
}
