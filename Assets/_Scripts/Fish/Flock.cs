using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] public float speed = 0.7f;
    [SerializeField] float rotationSpeed = 4f;
    Vector3 averageHeading;
    Vector3 averagePosition;

    [SerializeField] float neighbourDistance = 2f;

    bool turning = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Vector3.zero)>= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else { turning = false; }

        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.01f, 0.3f);  
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
        }
        transform.Translate(-Time.deltaTime * speed, 0, -Time.deltaTime * speed);
        if(Random.Range(0,5)<1)
        {
            ApplyRules();
        }
       
     
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            { 
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (dist <1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0) 
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }

    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] public float speed = 0.1f;
    [SerializeField] float rotationSpeed = .2f;
    [SerializeField] float neighbourDistance = .5f;
    [SerializeField] float avoidDistance = .2f; // Distance to avoid other fish
    [SerializeField] float objectAvoidDistance = 1f; // Distance to avoid objects or colliders

    bool turning = false;

    void Start()
    {
        speed = Random.Range(0.1f, 0.5f);
    }

    void Update()
    {
        // Turn back when reaching the tank boundary
        if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            TurnBackToTank();
        }
        else
        {
            if (Random.Range(0, 5) < 1)
            {
                ApplyFlockRules();
            }
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void TurnBackToTank()
    {
        Vector3 direction = Vector3.zero - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        speed = Random.Range(0.5f, 1.0f);
    }

    void ApplyFlockRules()
    {
        GameObject[] fishObjects = GlobalFlock.allFish;
        Vector3 groupCenter = Vector3.zero;
        Vector3 avoidVector = Vector3.zero;
        Vector3 objectAvoidVector = Vector3.zero;
        float groupSpeed = 0.0f;
        int groupSize = 0;

        foreach (GameObject fish in fishObjects)
        {
            if (fish != this.gameObject)
            {
                float distance = Vector3.Distance(fish.transform.position, this.transform.position);

                // Cohesion and Alignment
                if (distance <= neighbourDistance)
                {
                    groupCenter += fish.transform.position;
                    groupSpeed += fish.GetComponent<Flock>().speed;
                    groupSize++;
                }

                // Separation
                if (distance < avoidDistance)
                {
                    avoidVector += (this.transform.position - fish.transform.position);
                }
            }
        }

        // Object avoidance (can be expanded to include multiple types of objects)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, objectAvoidDistance))
        {
            objectAvoidVector = hit.point - transform.position;
        }

        if (groupSize > 0)
        {
            Vector3 newDirection = ((groupCenter / groupSize) + avoidVector + objectAvoidVector) - transform.position;

            if (newDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDirection), rotationSpeed * Time.deltaTime);
            }

            speed = Mathf.Clamp(groupSpeed / groupSize, 0.1f, 0.5f);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a TerrainCollider
        if (collision.gameObject.GetComponent<TerrainCollider>() != null)
        {
            // Change direction upon collision with terrain
            Vector3 reflectDir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
    }
}
*/