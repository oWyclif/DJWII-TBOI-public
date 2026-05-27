using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossBaseState currentState;
    BossStateIdle IdleState = new BossStateIdle();
    BossStateMover MoverState = new BossStateMover();
    BossStateAtaque AtaqueState = new BossStateAtque();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
