using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private GameBehavior gameBehavior;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    private int lives = 6;
    public int EnemyLives
    {

        get { return lives; }

        private set
        {

            lives = value;

            if (lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        gameBehavior = FindObjectOfType<GameBehavior>();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();

    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {

            MoveToNextPatrolLocation();

        }

    }

    void InitializePatrolRoute()
    {

        foreach (Transform child in patrolRoute)
        {

            locations.Add(child);

        }

    }

    void MoveToNextPatrolLocation()
    {

        if (locations.Count == 0)
        {

            return;

        }

        agent.destination = locations[locationIndex].position;
        Debug.Log(locationIndex + " " + locations.Count);
        locationIndex = (locationIndex + 1) % locations.Count;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player")
        {

            agent.destination = player.position;

            Debug.Log("Player detected - attack!");

        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {

            Debug.Log("Player out of range, resume patrol");

        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Bullet(Clone)")
        {

            LivesChange(-gameBehavior.Damage);

            Debug.Log("Critical hit!");

        }

    }

    void LivesChange(int value)
    {

        EnemyLives += value;

    }
}
