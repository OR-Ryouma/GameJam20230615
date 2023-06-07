using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �A�^�b�`����GameObject��Rigidbody���A�^�b�`����Ă��Ȃ��ꍇ�A�A�^�b�`����
[RequireComponent(typeof(Rigidbody))]

public class PlayerController1 : MonoBehaviour
{
    // �ړ����x��ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _speed = 1.0f;

    // �A�^�b�`���Ă���GameObject��Rigidbody���i�[����ϐ�
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // �A�^�b�`���Ă���GameObject��Rigidbody���擾
        //�iFixedUpdate()���Ŗ���擾����Ə������d���Ȃ�̂ŁAStart()�Ŏ擾����
        _rigidBody = GetComponent<Rigidbody>();
    }

    //��b�ԂɈ��̉񐔌Ă΂��
    //���������̍X�V�����Ԑi�s�P�ʂōs���Ă��邽�߁A�t���[���X�V�͊֌W�Ȃ����߁BFixedUpdate�͕��������X�V�O�ɌĂяo����邽�߁A���̒��ōs�����ǂ̂悤�ȕύX�����ڔ��f�����
    private void FixedUpdate()
    {
        // ���E�̃L�[�̓��͂��擾
        float x = Input.GetAxisRaw("Horizontal");
        // �O��̃L�[�̓��͂��擾
        //float z = Input.GetAxisRaw+("Vertical");

        // �㉺���E�L�[����͂��ē����l��speed���������l��AddForce�ɐݒ肵�Ĉړ�������
        //�iForceMode.Impulse�͏u�ԓI�ɗ͂�������Ƃ������Ɓj
        _rigidBody.AddForce(x * _speed, 0, _speed, ForceMode.Impulse);
    }
}