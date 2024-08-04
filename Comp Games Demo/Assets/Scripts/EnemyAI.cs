using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Floor, isPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Cube").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check sight and range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if(!playerInSightRange) Patroling();
        if(playerInSightRange) ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 5f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, Floor))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    //private void AttackPlayer()
    // {
    //     agent.SetDestination(transform.position);
    //     transform.LookAt(player);

    //     if(!alreadyAttacked)
    //     {
    //         alreadyAttacked = true;
    //         Invoke(nameof(ResetAttack), timeBetweenAttacks);
    //     }
    // }

    // private void ResetAttack()
    // {
    //     alreadyAttacked = false;
    // }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("AttackCube"))
        {
            Destroy(gameObject);
        }
    }
}