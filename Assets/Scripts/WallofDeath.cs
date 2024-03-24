using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallofDeath : MonoBehaviour
{
    public float speed = 5f; 
    [SerializeField] GameObject player;
    public PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.ResetTimer();
            playerMovement.failedCon = true;
            Destroy(player);
        }

    }



}
