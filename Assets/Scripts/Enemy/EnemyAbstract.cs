using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyAbstract : MonoBehaviour
{
    protected NavMeshAgent agent;
    public float MovementSpeed;
    public float SearchRadius;
    public List<Transform> PatrolPoints;
    private int targetPatrolPoint = 0;

    protected abstract void Start();
    protected virtual void Update(){
        if(IsInSight())
            chase();
        else
            patrol();
    }
    protected virtual void patrol(){
        if(agent.pathPending || agent.remainingDistance > 0.1f)
            return;
        targetPatrolPoint++;
        if(targetPatrolPoint >= PatrolPoints.Count)
            targetPatrolPoint = 0;
        Debug.Log(targetPatrolPoint);
        agent.destination = PatrolPoints[targetPatrolPoint].position;
    }
    protected virtual void chase(){
        return;
    }
    protected virtual bool IsInSight(){
        return false;
    }

}
