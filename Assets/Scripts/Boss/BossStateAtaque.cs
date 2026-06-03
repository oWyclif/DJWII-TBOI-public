using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateAtaque : BossBaseState
{
    Transform bossTransform;

    float bossAtaqueSpeed = 0.08f;


    GameObject player; 
    Transform playerTransform;
    public override void EnterState(BossStateManager boss){
        //Debug.Log("Boss Atacando");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        bossTransform = GameObject.Find("boss").GetComponent<Transform>();

        // Nesse momento, resetamos a escala do boss (ele é 3 x 3)
        bossTransform.localScale = new Vector3(3, 3, 1);
    }

    public override void UpdateState(BossStateManager boss){
        //Movemos o boss em direção ao player de modo BEM rápido.
        bossTransform.position = Vector2.MoveTowards(bossTransform.position, playerTransform.position, bossAtaqueSpeed);
    
        //Para evitar que o boss se prenda ao player, verificamos se ele está na mesma posição do
        // boss. Se for o caso, retornamos ao Idle.
        if (bossTransform.position.x == playerTransform.position.x && 
            bossTransform.position.y == playerTransform.position.y)
        {
            boss.SwitchState(boss.IdleState);
        }
    }

    // Qualquer colisão nos retorna ao idle
    public override void OnCollisionEnter(BossStateManager boss, Collision collision){
        boss.SwitchState(boss.IdleState);
    }
    public override void OnTriggerEnter(BossStateManager boss, Collider2D collider){
        boss.SwitchState(boss.IdleState);        
    }

}
