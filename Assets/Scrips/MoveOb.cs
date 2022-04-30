using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOb : MonoBehaviour
{
    [SerializeField] Vector3 MovementVector;
    [SerializeField] [Range(-1, 1)] float MovementFactor;
    //Vector3 StartPos;
    [SerializeField] float period = 3f;
     void Start()
    {
        //StartPos = transform.position;
    }

     void Update()
    {
        if (period == 0f) return;

        float Cycle = Time.time / period;
        const float Rad = Mathf.PI ;
        float RawSinWave = Mathf.Sin(Cycle * Rad);
        MovementFactor = RawSinWave;

        Vector3 Offset = MovementVector * MovementFactor;
        transform.position = transform.position + Offset;
    }
}
