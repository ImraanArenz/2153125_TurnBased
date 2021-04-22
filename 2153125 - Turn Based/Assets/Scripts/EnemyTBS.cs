using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTBS : MonoBehaviour
{
    public PlayerScript Protagon;
    private void OnCollisionEnter2D(Collision2D Battle)
    {
        if (Battle.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game");
        }
    }
    private void Update()
    {
        Delete();
    }
    public void Delete()
    {
        if (Protagon.PassPt == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
