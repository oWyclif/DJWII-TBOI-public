using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateIdle : BossBaseState
{


    public override void EnterState(BossStateManager boss){
        Debug.Log("Boss inicializado");

        // Ao inicializar o state idle eu já lanço o método de escolher o próximo
        // state. Eu poderia esperar, se quissesse.
        Escolher(boss);
    }

    public override void UpdateState(BossStateManager boss){
    }

    public override void OnCollisionEnter(BossStateManager boss, Collision collision){

    }

    void Escolher(BossStateManager boss)
    {
        //Aqui eu defino uma variável int i e assinalo ela aleatoriamente 
        int i;
        i = Random.Range(1, 10);

        if (i < 7) // Depois transformar esse 7 numa variável
        {
            boss.SwitchState(boss.MoverState);
        }
        else
        {
            boss.SwitchState(boss.AtaqueState);
        }
    }

}
