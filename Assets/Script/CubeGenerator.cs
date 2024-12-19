using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // キューブのPrefab
    private float delta = 0; // 時間計測用の変数
    private float span = 1.0f; // キューブの生成間隔
    private float genPosX = 12; // キューブの生成位置：X座標
    private float offsetY = 6.9f; // キューブの生成位置オフセット
    private float spaceY = 6.9f; // キューブの縦方向の間隔
    private float offsetX = 0.5f; // キューブの生成位置オフセット
    private float spaceX = 0.4f; // キューブの横方向の間隔
    private int maxBlockNum = 4;  // キューブの生成個数の上限

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; //毎フレーム間の時間を加算することで、delta変数には経過時間が代入されます

        if (this.delta > this.span) // span秒以上の時間が経過したかを調べる
        {
            this.delta = 0;
            int n = Random.Range(1, maxBlockNum+1); // 生成するキューブ数をランダムに決める

            for (int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);  // キューブの生成,縦方向にspaceY変数のぶんだけスペースを空けて生成
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offsetX + this.spaceX * n;  // 次のキューブまでの生成時間を決める
        }
    }
}
