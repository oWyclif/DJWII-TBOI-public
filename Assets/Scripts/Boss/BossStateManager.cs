using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
    BossStateIdle IdleState = new BossStateIdle();
    BossStateMover MoverState = new BossStateMover();
    BossStateAtaque AtaqueState = new BossStateAtaque();

    void Start()
    {
        //Ao iniciar nosso script, definimos o state do boss como Idle. 
        currentState = IdleState;

        //Depois de definir o state do boss como idle, rodamos a função "EnterState();
        //que ele herda do "template" (BossBaseState).
        currentState.EnterState(this);
    }

    void Update()
    {
        
    }
    // O commit anterior duplicou lol
}
