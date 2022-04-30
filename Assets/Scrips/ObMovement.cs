using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMovement : MonoBehaviour
{
    Vector3 StartPos;
    [SerializeField] float period = 10f;
    //[SerializeField] Vector3 MovementVector;
   [SerializeField] [Range(0,1)] float MovementFactor;
    private void Start()
    {
        StartPos = transform.position;//��ֱ����start����������Ĭ��ֵΪ000����Ҳ��֪Ϊɶ��
    }
    void Update()
    {
        float Cycle = Time.time * period;
        const float JiaoSuDu = Mathf.PI*2f;
        float SinWave = Mathf.Sin(JiaoSuDu * Cycle);
        MovementFactor = SinWave + 1;
        Vector3 Direction = transform.forward*10;
        Vector3 Offset = Direction * MovementFactor;
        transform.position = StartPos + Offset;
    }
}
