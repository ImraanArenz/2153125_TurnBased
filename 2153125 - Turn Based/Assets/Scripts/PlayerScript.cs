using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D TBSPlayer;
    public int PassPt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        Vector2 PlayerMovementTBS = TBSPlayer.velocity;

        TBSPlayer.velocity = new Vector2(MoveX * moveSpeed, MoveY * moveSpeed);
    }
}
