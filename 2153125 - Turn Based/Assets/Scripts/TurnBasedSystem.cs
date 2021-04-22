using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public EnemyHUD enemyHUD;
    public Text infoText;
    public Text MPText;
    public PlayerScript Protago;
    public Button LIMITBREAKBUTT;
    public Button MPButton;

    private void Start()
    {
        CurrentState = BattleStateMachine.BeginBattle;
        StartCoroutine(StartBattle());
        LIMITBREAKBUTT.gameObject.SetActive(false);
        
    }
    private void Update()
    {
        if(PlayerCharUnit.CurrentHealth <= PlayerCharUnit.LimitBreakDamageThreshold)
        {
            LIMITBREAKBUTT.gameObject.SetActive(true);
        }
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
            BattleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.EnemyTurn;
            StartCoroutine(EnemyNoTurn());
        }
    }

    IEnumerator MagicAttack()
    {
        //PlayerCharUnit.MP.ToString() == MPText.text;
        PlayerCharUnit.MP--;
        MPText.text = PlayerCharUnit.MP.ToString();
        bool Dead = EnemyCharUnit.MagicDamage(PlayerCharUnit.MagicDamageOutput);
        Instantiate(EnemyCharUnit.MagicPart);
        infoText.text = "Virus corruption damage!!!";

        if(PlayerCharUnit.MP <= 0)
        {
            MPButton.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(3f);

        if (Dead)
        {
            CurrentState = BattleStateMachine.PlayerWin;
            BattleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.EnemyTurn;
            StartCoroutine(EnemyNoTurn());
        }
    }

    public void BattleOver()
    {
        if (CurrentState == BattleStateMachine.PlayerWin)
        {
            infoText.text = "You Win!";
            Protago.PassPt++;
            SceneManager.LoadScene("Hub Level");
            
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

        bool PlayerDead = PlayerCharUnit.Damage(EnemyCharUnit.DamageOutput);

        playerHUD.PlayerHP(PlayerCharUnit.CurrentHealth);
        Instantiate(PlayerCharUnit.DamagePart);
        yield return new WaitForSeconds(2f);

        if (PlayerDead)
        {
            CurrentState = BattleStateMachine.PlayerLose;
            BattleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.PlayerTurn;
            PlayerNoTurn();
        }


    }

    IEnumerator LimitBREAK()
    {
        bool Dead = EnemyCharUnit.LimitBreakDamage(PlayerCharUnit.LimitBreakDamageOutput);
        Instantiate(PlayerCharUnit.LimitBREAKPart);
        infoText.text = "LIMIT BREAK!!!!!";

        yield return new WaitForSeconds(3f);

        if (Dead)
        {
            CurrentState = BattleStateMachine.PlayerWin;
            BattleOver();
        }
        else
        {
            CurrentState = BattleStateMachine.EnemyTurn;
            StartCoroutine(EnemyNoTurn());
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

    public void LimitBREAKButton()
    {
        if(CurrentState != BattleStateMachine.PlayerTurn)
        {
            return;
        }
        else
        {
            StartCoroutine(LimitBREAK());
        }
    }
}
