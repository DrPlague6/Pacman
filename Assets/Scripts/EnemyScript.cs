using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    protected NavMeshAgent agent;
    [SerializeField] List<Transform> PatrolPoints;
    private int targetPatrolPoint = 0;
    public GhostObject entityObject;
    public GameObject chasedPlayer;
    public LayerMask playerLayerMask;
    protected virtual void Start(){
        agent = GetComponent<NavMeshAgent>();
        agent.speed = entityObject.MovementSpeed;
        playerLayerMask = LayerMask.GetMask("Player");
    }
    protected virtual void Update(){
        if(IsInSight(chasedPlayer))
            chasePlayer(chasedPlayer);
        else if(agent.pathPending || agent.remainingDistance < 0.1f ){
            patrol();
        }
    }
    protected virtual void patrol(){
        targetPatrolPoint++;
        if(targetPatrolPoint >= PatrolPoints.Count)
            targetPatrolPoint = 0;
        Debug.Log("Patrol");
        agent.destination = PatrolPoints[targetPatrolPoint].position;
    }
    public bool IsInSight(GameObject target){
        RaycastHit castHit;
        if(Physics.CheckSphere(transform.position,entityObject.SearchRadius,playerLayerMask)){
            if(Physics.SphereCast(transform.position,3f,target.transform.position,out castHit,Mathf.Infinity,playerLayerMask))
                return true;
        }
        return false;
    }

    protected void chasePlayer(GameObject target){
        agent.destination = target.transform.position;
    }
}