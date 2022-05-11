using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyAbstract : MonoBehaviour
{
    private NavMeshAgent agent;
    public float MovementSpeed;
    public float SearchRadius;
    public List<Transform> PatrolPoints;
    private int targetPatrolPoint;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }
    void Update(){
        float distance = Vector3.Distance(transform.position,PatrolPoints[targetPatrolPoint].position);
        if(distance > 20)
            return;
        targetPatrolPoint++;
        agent.destination = PatrolPoints[targetPatrolPoint].position;
    }
    private void patrol(){
    }
    private void chase(){

    }
    private void IsInSight(){

    }

}
