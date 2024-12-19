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
        transform.Translate (this.speed*Time.deltaTime, 0, 0); //Translate関数は、引数に与えた値のぶんだけ現在の位置から移動
                                                               //Time.deltaTimeは前フレームからの経過時間を表します。フレームレートが高ければ小さく、フレームレートが低ければ大きくなります。
        
            if (transform.position.x < this.deadLine)
        {
            GetComponent<AudioSource>().volume = 0;
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //Colliderが他のオブジェクトのColliderと接触した時に呼ばれる
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
