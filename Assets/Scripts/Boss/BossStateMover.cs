using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMover : BossBaseState
{
    GameObject p  = new GameObject(); 

    Transform pTransform;
    
    public override void EnterState(BossStateManager boss){
        Debug.Log("Boss Movendo");

        p = GameObject.Find("player"); //Aqui encontramos o Objeto player
        pTransform = p.GetComponent<Transform>(); // E definimos o ptransform,
        // a posição do player
    }

    public override void UpdateState(BossStateManager boss){

    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){

    }
}
