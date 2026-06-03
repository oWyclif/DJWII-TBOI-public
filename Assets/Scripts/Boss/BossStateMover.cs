using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMover : BossBaseState
{
    Transform bossTransform;
    float bossMoverSpeed = 0.003f;


    public GameObject player; 
    public Transform playerTransform;
    
    public override void EnterState(BossStateManager boss){
        //Debug.Log("Boss Movendo");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        bossTransform = GameObject.Find("boss").GetComponent<Transform>();
    }

    public override void UpdateState(BossStateManager boss){
        bossTransform.position = Vector2.MoveTowards(bossTransform.position, playerTransform.position, bossMoverSpeed);
    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){
         
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider2D collider){
        Debug.Log("Vai atacar");
        boss.SwitchState(boss.PrepAtaqueState);
    }
}
