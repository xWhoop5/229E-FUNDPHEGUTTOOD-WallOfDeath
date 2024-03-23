using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    void Start()
    {
        // คำนวณระยะห่างเริ่มต้นระหว่างกล้องกับเป้าหมาย
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // ตำแหน่งเป้าหมายที่เกิดจากการเคลื่อนที่ของผู้เล่นบนแกน x และ z เท่านั้น
        Vector3 targetCamPos = target.position + offset;

        // ปรับความลื่นของการเคลื่อนที่ของกล้อง
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
