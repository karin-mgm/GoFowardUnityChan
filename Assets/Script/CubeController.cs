using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12;

    private float deadLine = -10;

    private bool ColliderVolumeFlg;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (this.speed*Time.deltaTime, 0, 0); //Translate�֐��́A�����ɗ^�����l�̂Ԃ񂾂����݂̈ʒu����ړ�
                                                               //Time.deltaTime�͑O�t���[������̌o�ߎ��Ԃ�\���܂��B�t���[�����[�g��������Ώ������A�t���[�����[�g���Ⴏ��Α傫���Ȃ�܂��B
        
            if (transform.position.x < this.deadLine)
        {
            GetComponent<AudioSource>().volume = 0;
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Collider�����̃I�u�W�F�N�g��Collider�ƐڐG�������ɌĂ΂��
    {
        ColliderVolumeFlg = true;
        GetComponent<AudioSource>().volume = 1;
        Debug.Log(this.ColliderVolumeFlg);

        if (collision.gameObject.CompareTag("UnityChan") )
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
