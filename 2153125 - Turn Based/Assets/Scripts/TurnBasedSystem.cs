using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStateMachine { BeginBattle, PlayerTurn, EnemyTurn, PlayerWin, PlayerLose}
public class TurnBasedSystem : MonoBehaviour
{
    public BattleStateMachine CurrentState;
    public Transform PlayerPos;
    public Transform enemyPos;

    private void Start()
    {
        CurrentState = BattleStateMachine.BeginBattle;
        StartBattle();
    }

    void StartBattle()
    {
        Instantiate(playerPrefab)

    }
}
