using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วการเคลื่อนที่ของผู้เล่น
    public float jumpForce = 10f; // แรงกระโดดของผู้เล่น
    public float windResistance = 2f; // ความต้านทานของลม

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
       
    }

    // Update is called once per frame
    void Update()
    {
        // การเคลื่อนที่แนวนอน
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.AddForce(moveDirection * moveSpeed * (isGrounded ? 1f : windResistance));

        // การกระโดด
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (timerActive)
        {
            // คำนวณเวลาที่ผ่านไป
            float t = Time.time - startTime;

            // แปลงเวลาให้อยู่ในรูปแบบนาที:วินาที:เซ็คเม้นต์
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((int)(t * 1000) % 1000).ToString("000");

            // แสดงผลลัพธ์บน Text UI
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าผู้เล่นอยู่บนพื้นหรือไม่
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // ตรวจสอบว่าผู้เล่นหลุดจากพื้นหรือไม่
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

    // หยุดเครื่องจับเวลา
    public void StopTimer()
    {
        timerActive = false;
    }
    // รีเซ็ตเครื่องจับเวลา
    public void ResetTimer()
    {
        startTime = Time.time;
    }

   

   
}
