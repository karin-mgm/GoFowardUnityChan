using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;

    private float gloundLevel = 3.6f;
    private float dump = 0.8f;
    float jumpVelocity = 20;
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>(); //Animator�R���|�[�l���g���g���ă��j�e�B�����̃A�j���[�V�����Đ����X�N���v�g�Ő���
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetFloat("Horizontal", 1); //�E�����ɑ���A�j���[�V�������Đ����邽�߁AHorizontal�����1

        bool isGround = (transform.position.y > this.gloundLevel) ? false : true; //���n���Ă��邩���ׂ�A���j�e�B����񂪒��n���Ă���ꍇ��isGround��true�ɐݒ�
                                  //�O�����Z�q�̏���:�l��������ϐ� = (������) ? �ϐ�1 : �ϐ�2;
        this.animator.SetBool ("isGround", isGround);

        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;  // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity); //Rigidbody2D�R���|�[�l���g���擾���ă��j�e�B�����ɏ�����̗͂�������
        }

        if (Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        if (transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            Destroy(gameObject);
        }
    }
}
