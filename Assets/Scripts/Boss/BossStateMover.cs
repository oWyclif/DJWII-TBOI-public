using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMover : BossBaseState
{
    Transform bossTransform;
    float bossSpeed = 0.003f;


    GameObject player; 
    Transform playerTransform;
    
    public override void EnterState(BossStateManager boss){
        Debug.Log("Boss Movendo");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        bossTransform = GameObject.Find("boss").GetComponent<Transform>();
    }

    public override void UpdateState(BossStateManager boss){
        bossTransform.position = Vector2.MoveTowards(bossTransform.position, playerTransform.position, bossSpeed);
    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){

    }
}
