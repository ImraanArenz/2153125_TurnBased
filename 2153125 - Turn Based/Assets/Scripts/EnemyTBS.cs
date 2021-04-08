using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTBS : MonoBehaviour
{
    bool isDefeated = false;
    private void OnCollisionEnter2D(Collision2D Battle)
    {
        if (Battle.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
