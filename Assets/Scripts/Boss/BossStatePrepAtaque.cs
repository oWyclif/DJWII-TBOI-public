using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatePrepAtaque : BossBaseState
{
    // Pegamos o componente transform do boss, para medir e mudar sua velocidade ou posiçõa
    Transform bossTransform;

    // Nessa parte definimos as nossas variáveis para manipular a escala do boss
    Vector3 startScale;
    Vector3 targetScale = Vector3.one * 5.0f;
    float t = 0f;

    // E aqui vai nossas variáveis relacionadas ao player
    GameObject player; 
    Transform playerTransform;
    
    public override void EnterState(BossStateManager boss){
        //Debug.Log("Boss Preparando Ataque");

        player = GameObject.Find("player"); //Aqui encontramos o Objeto player
        playerTransform = player.GetComponent<Transform>(); // E definimos o playertransform,
        // a posição do player

        // Encontramos o objeto boss e pegamos seu componente Transform
        bossTransform = GameObject.Find("boss").GetComponent<Transform>();

        // Definimos a escala inicial do boss.
        startScale = bossTransform.localScale;
    }

    public override void UpdateState(BossStateManager boss){
        t += Time.deltaTime / 1f;

        // Transformamos linearmente a escala do boss em todos os frames
        Vector3 newScale = Vector3.Lerp(startScale, targetScale, t);
        bossTransform.localScale = newScale;

        // Até ela atingir 5, quando iniciamos a segunda parte do ataque, o ataque em si
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
