using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostBig : EnemyAbstract
{
    protected override void Start(){
        base.agent = GetComponent<NavMeshAgent>();
        base.MovementSpeed = 2;
        base.SearchRadius = 10;
    }
}
