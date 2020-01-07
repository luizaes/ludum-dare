using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Transform trans;
    public GameObject planet;
    public GameObject asteroid;
    public GameObject emptyAsteroid;
    public Animator asteroidAnim;
    public Text scoreText;
    private float radius = 4f;
    private float spawnRate = 5.0f;
    private float nextSpawn;
    private int velocity;
    private int side;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("createAsteroid", 0.0f, 5.0f);
        velocity = 1000;
        score = 0;
        PlayerPrefs.SetInt("Score", score);
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
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
            obj.GetComponent<Asteroid>().velocity = velocity;
        }
        else if (side == 1)
        {
            Vector3 position = new Vector3(15f, Random.Range(-6f, 6f), 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
            obj.GetComponent<Asteroid>().velocity = velocity;
        }
        else if (side == 2)
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), -8f, 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
            obj.GetComponent<Asteroid>().velocity = velocity;
        }
        else
        {
            Vector3 position = new Vector3(-15f, Random.Range(-6f, 6f), 0f);
            GameObject obj = Instantiate(asteroid) as GameObject;
            obj.transform.position = position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(emptyAsteroid.transform);
            obj.GetComponent<Asteroid>().velocity = velocity;
        }
        nextSpawn = Time.time + spawnRate;
        if (velocity > 100)
        {
            velocity -= 50;
            Debug.Log(velocity);
        }
        if(spawnRate > 1.0f)
        {
            spawnRate -= 0.1f;
            Debug.Log(spawnRate);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            //StartCoroutine(ExplodeAsteroid(collision));
            Destroy(collision.gameObject);
            score += 1;
        }
    }

    //IEnumerator ExplodeAsteroid(Collision2D collision)
    //{
    //    asteroidAnim.SetTrigger("Explode");

    //    //yield on a new YieldInstruction that waits for 5 seconds.
    //    yield return new WaitForSeconds(5);

    //    Destroy(collision.gameObject);
    //}
}
