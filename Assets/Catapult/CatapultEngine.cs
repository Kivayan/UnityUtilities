using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultEngine : MonoBehaviour {

    public Transform target;
    public float distanceToTarget;

    public GameObject projectilePrefab;
    //public float force = 1000f;

	void Start () {

        target = GameObject.Find("Target").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        GetDistToTarget();
        transform.LookAt(target);
        MonitorFire();
        
	}

    private void GetDistToTarget()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
    }

    private void Fire()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x -45 , transform.eulerAngles.y, transform.eulerAngles.z));
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        projectile.transform.parent = transform;

        float force = 25 * distanceToTarget;
       
        DebugPanel.Log("force", force);

        rb.AddRelativeForce(Vector3.forward * force);
    }
    private void MonitorFire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    
}
