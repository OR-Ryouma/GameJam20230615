using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �A�^�b�`����GameObject��CharacterController���A�^�b�`����Ă��Ȃ��ꍇ�A�A�^�b�`����
[RequireComponent(typeof(CharacterController))]

public class PlayerController2 : MonoBehaviour
{
    // �A�^�b�`���Ă���GameObject��CharacterController���i�[����ϐ�
    private CharacterController _characterController;
    //Vector3�̐ݒ�
    Vector3 _movedir = Vector3.zero;
    //�����̂��郉�C�����i�[����ϐ�
    private int _lane;

    // �W�����v�͂�ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _jumpPower = 10f;
    // X���̃X�s�[�h��ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _speedX = 1.0f;
    // Z���̃X�s�[�h��ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _speedZ = 1.0f;
    // �H�H�H��ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _acceleratorZ = 0.1f;

    // �d�͂�ݒ�iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private float _gravity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // �A�^�b�`���Ă���GameObject��CharacterController���擾
        //�iFixedUpdate()���Ŗ���擾����Ə������d���Ȃ�̂ŁAStart()�Ŏ擾����
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ���E��Space�̃L�[�̓���
        //����Ɖ��������߂Ă������Ƃɂ�肻��ȏ㍶�E�ɓ����Ȃ������Ă���
        if((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            if(_characterController.isGrounded && _lane > -2f)
            {
                _lane--;
            }
        }

        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            if (_characterController.isGrounded && _lane < 2f)
            {
                _lane++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_characterController.isGrounded)
            {
                _movedir.y = _jumpPower;
            }
        }

        //Mathf.Clamp�֐��́A�������̒l���A�������Ƒ�O�����̊ԂŎ��܂�悤�ɂ��鏈���B����ɂ�菙�X�ɉ������ō����x�𒴂��Ȃ��悤�ɂ��Ă���
        _movedir.z = Mathf.Clamp(_movedir.z + (_acceleratorZ * Time.deltaTime), 0, _speedZ);

        float _ratioX = (_lane * 1.0f - transform.position.x) / 1.0f;
        _movedir.x = _ratioX * _speedX;
        //�d�͂̒ǉ�
        _movedir.y -= _gravity * Time.deltaTime;

        Vector3 _globalgir = transform.TransformDirection(_movedir);
        _characterController.Move(_globalgir * Time.deltaTime);

        if(_characterController.isGrounded)
        {
            //�n�ʂ����m����ƒl��0�ɏ���������B
            _movedir.y = 0f;
        }
    }
}
