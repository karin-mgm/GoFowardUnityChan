using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // �L���[�u��Prefab
    private float delta = 0; // ���Ԍv���p�̕ϐ�
    private float span = 1.0f; // �L���[�u�̐����Ԋu
    private float genPosX = 12; // �L���[�u�̐����ʒu�FX���W
    private float offsetY = 6.9f; // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float spaceY = 6.9f; // �L���[�u�̏c�����̊Ԋu
    private float offsetX = 0.5f; // �L���[�u�̐����ʒu�I�t�Z�b�g
    private float spaceX = 0.4f; // �L���[�u�̉������̊Ԋu
    private int maxBlockNum = 4;  // �L���[�u�̐������̏��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; //���t���[���Ԃ̎��Ԃ����Z���邱�ƂŁAdelta�ϐ��ɂ͌o�ߎ��Ԃ��������܂�

        if (this.delta > this.span) // span�b�ȏ�̎��Ԃ��o�߂������𒲂ׂ�
        {
            this.delta = 0;
            int n = Random.Range(1, maxBlockNum+1); // ��������L���[�u���������_���Ɍ��߂�

            for (int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);  // �L���[�u�̐���,�c������spaceY�ϐ��̂Ԃ񂾂��X�y�[�X���󂯂Đ���
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offsetX + this.spaceX * n;  // ���̃L���[�u�܂ł̐������Ԃ����߂�
        }
    }
}
