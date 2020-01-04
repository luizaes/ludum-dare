using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform trans;
    public GameObject planet;
    public GameObject asteroid;
    public GameObject emptyAsteroid;
    private float radius = 4f;
    private float spawnRate = 5.0f;
    private float nextSpawn;
    private int side;

    // Start is called before the first frame update
    void Start()
    { 
        //InvokeRepeating("createAsteroid", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move player acording to mouse position and radius 
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = planet.transform.position.z - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mousePosition - planet.transform.position;
        direction = Vector3.ClampMagnitude(direction, radius);

        if ((double)direction.sqrMagnitude < (double)radius * (double)radius)
        {
            direction = direction.normalized * radius;
        }

        trans.position = planet.transform.position + direction;

        // Instantiate asteroids
        if (Time.time > nextSpawn)
        {
            createAsteroid();
        }

    }

    void createAsteroid()
    {
        side = (int)Random.Range(0, 4);

        Debug.Log(side);

        if (side == 0)
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), 8f, 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
        }
        else if (side == 1)
        {
            Vector3 position = new Vector3(15f, Random.Range(-6f, 6f), 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
        }
        else if (side == 2)
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), -8f, 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
        }
        else
        {
            Vector3 position = new Vector3(-15f, Random.Range(-6f, 6f), 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
        }
        nextSpawn = Time.time + spawnRate;
    }
}
