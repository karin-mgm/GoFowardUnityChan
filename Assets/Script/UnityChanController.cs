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
        this.animator = GetComponent<Animator>(); //Animatorコンポーネントを使ってユニティちゃんのアニメーション再生をスクリプトで制御
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetFloat("Horizontal", 1); //右方向に走るアニメーションを再生するため、Horizontalを常に1

        bool isGround = (transform.position.y > this.gloundLevel) ? false : true; //着地しているか調べる、ユニティちゃんが着地している場合はisGroundをtrueに設定
                                  //三項演算子の書式:値を代入する変数 = (条件式) ? 変数1 : 変数2;
        this.animator.SetBool ("isGround", isGround);

        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;  // ジャンプ状態のときにはボリュームを0にする

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity); //Rigidbody2Dコンポーネントを取得してユニティちゃんに上向きの力をかける
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
