using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アタッチしたGameObjectにRigidbodyがアタッチされていない場合、アタッチする
[RequireComponent(typeof(Rigidbody))]

public class PlayerController1 : MonoBehaviour
{
    // 移動速度を設定（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float _speed = 1.0f;

    // アタッチしているGameObjectのRigidbodyを格納する変数
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // アタッチしているGameObjectのRigidbodyを取得
        //（FixedUpdate()内で毎回取得すると処理が重くなるので、Start()で取得する
        _rigidBody = GetComponent<Rigidbody>();
    }

    //一秒間に一定の回数呼ばれる
    //物理挙動の更新が時間進行単位で行われているため、フレーム更新は関係ないため。FixedUpdateは物理挙動更新前に呼び出されるため、その中で行ったどのような変更も直接反映される
    private void FixedUpdate()
    {
        // 左右のキーの入力を取得
        float x = Input.GetAxisRaw("Horizontal");
        // 前後のキーの入力を取得
        //float z = Input.GetAxisRaw+("Vertical");

        // 上下左右キーを入力して得た値にspeedをかけた値をAddForceに設定して移動させる
        //（ForceMode.Impulseは瞬間的に力を加えるということ）
        _rigidBody.AddForce(x * _speed, 0, _speed, ForceMode.Impulse);
    }
}
