using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public float windResistance = 2f; 
    public bool failedCon = false;
    public bool winCon = false;

    private Rigidbody rb;
    private bool isGrounded;

    public TMP_Text timerText;
    private float startTime;
    private bool timerActive;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerActive = true;
        rb.AddForce(Vector3.fwd * 10);
       
    }

    // Update is called once per frame
    void Update()
    {

        // การกระโดด
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (timerActive)
        {
            
            float t = Time.time - startTime;

            
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((int)(t * 1000) % 1000).ToString("000");

           
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;

        }
    }

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.AddForce(moveDirection * moveSpeed * (isGrounded ? 1f : windResistance));   
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Death"))
        {   
            failedCon = true;
            Destroy(gameObject);            
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            winCon = true;
            Destroy(gameObject);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerActive = true;
    }

    
    public void StopTimer()
    {
        timerActive = false;
    }
   
    public void ResetTimer()
    {
        startTime = Time.time;
    } 
}
