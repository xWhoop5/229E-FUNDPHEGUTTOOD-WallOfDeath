using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public LayerMask obstacleMask; // ชั้นของสิ่งของที่จะต้องไม่ทะลุ
    public float smoothing = 5f;
    
    private Vector3 offset; // ระยะห่างระหว่างกล้องกับเป้าหมาย


    void Start()
    {
        // คำนวณระยะห่างเริ่มต้นระหว่างกล้องกับเป้าหมาย
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // คำนวณตำแหน่งเป้าหมายที่กล้องจะตาม
        Vector3 targetCamPos = target.position + offset;

        // ตรวจสอบว่ามีสิ่งของใด ๆ อยู่ระหว่างกล้องและเป้าหมายหรือไม่
        RaycastHit hit;
        if (Physics.Raycast(target.position, targetCamPos - target.position, out hit, offset.magnitude, obstacleMask))
        {
            // หากมีสิ่งของ ให้ปรับตำแหน่งของกล้องให้ห่างออกจากสิ่งของนั้น
            transform.position = hit.point;
        }
        else
        {
            // หากไม่มีสิ่งของ ให้ปรับตำแหน่งของกล้องไปที่เป้าหมาย
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
