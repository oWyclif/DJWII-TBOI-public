using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatePrepAtaque : BossBaseState
{
    Transform bossTransform;

    Vector3 startScale;
    Vector3 targetScale = Vector3.one * 5.0f;
    float t = 0f;



    GameObject player; 
    Transform playerTransform;
    public override void EnterState(BossStateManager boss){
        //Debug.Log("Boss Preparando Ataque");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        bossTransform = GameObject.Find("boss").GetComponent<Transform>();

        startScale = bossTransform.localScale;

        //Ataque();
    }

    public override void UpdateState(BossStateManager boss){
        t += Time.deltaTime / 1f;

        Vector3 newScale = Vector3.Lerp(startScale, targetScale, t);
        bossTransform.localScale = newScale;

        if (bossTransform.localScale.x == 5f)
        {
            boss.SwitchState(boss.AtaqueState);
            t = 0;
        }
    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){

    }
    public override void OnTriggerEnter(BossStateManager boss, Collider2D collider){
        
    }

}
