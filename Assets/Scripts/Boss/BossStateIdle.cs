using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateIdle : BossBaseState
{


    public override void EnterState(BossStateManager boss){
        Debug.Log("Boss inicializado");

        

    }

    public override void UpdateState(BossStateManager boss){
    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){

    }

}
