using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool isAlive = true;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {      
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();        
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }   
        if(transform.position.y > 20 || transform.position.y < -20)
        {           
            logic.gameOver();           
            isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();        
        isAlive = false;
    }
}
