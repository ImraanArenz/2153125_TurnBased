using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public PlayerScript PlayerPtGate;
    public string SceneProgression;
    public int PtsNeededToPass;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerPtGate.PassPt == PtsNeededToPass)
        {
            SceneManager.LoadScene(SceneProgression);
        }
    }
}
