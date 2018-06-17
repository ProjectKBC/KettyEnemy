using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

  // lenはインスペクター上で編集したくても、publicであるべきではない
  // この場合はスコープをprivateにして[SerializeField]を使うといいよ
  //public int len;
  [SerializeField]
  private int len;
  // 上に同じく
  //public GameObject enemy_pre;
  [SerializeField]
  private GameObject enemy_pre;
  // newは関数内でした方が安全
  // ※1
  private List<GameObject> enemys;// = new List<GameObject> ();
  private int count = 0;

  // 上に同じく
  //public bool test_flg = false; //作られてることが目に見えるようにするためのテスト用flg

  /// <summary>
  /// 作られてることが目に見えるようにするためのテスト用flg
  /// </summary>
  [SerializeField]
  private bool test_flg = false;

  // 関数にもスコープをつけようぜ
  //void Start () {
  private void Start() {
        enemys = new List<GameObject>();
    for (int i = 0; i < len; i++) {
      CreateEnemy (false, -i);
    }
  }

  //void Update () {
  private void Update () {
    if (Input.GetKey (KeyCode.T)) {
      count++;
      GameObject ene;
      ene = GetEnemy ();
      Debug.Log(enemys.Count);
    }
    if (Input.GetKey (KeyCode.F)) {
      foreach (GameObject obj in enemys) {
        if (obj.activeSelf) {
          // ここは「プールに返す（ある意味破棄する）処理」として関数化した方がいい
          // あと初期化しないとダメよ(ここ重要)
          // EnemyをMoveさせてみるとわかるかも
          obj.SetActive (false);
          break;
        }
      }
    }
  }

  //GameObject GetEnemy () {
  private GameObject GetEnemy () {
    // ※1
    foreach (GameObject obj in enemys) {
      if (!obj.activeSelf) {
        obj.SetActive(true);
        return obj;
      }
    }
    CreateEnemy (true, 1 * count);
    return enemys [enemys.Count - 1];
  }

  // len以上のオブジェクトを生成したときにInstantiate()する仕様は別のアプローチを考えた方がいいかも
  // というのは、オブジェクトプーリングは「生成(Instantiate)と破棄(Destroy)のコストを抑えよう」という趣旨だから
  //void CreateEnemy (bool flg, int y) {
  private void CreateEnemy (bool flg, int y) {
    GameObject enemy;
    enemy = (GameObject)Instantiate (enemy_pre, new Vector3 (this.transform.position.x, y, this.transform.position.z), Quaternion.identity);
    enemy.transform.localScale = new Vector3 (30, 30, 30);
    enemy.gameObject.SetActive (flg);
    enemy.transform.parent = this.transform;
    enemys.Add (enemy);
  }

}

// ※1　おまけ「最適化の話」
// Listより固定配列の方が参照速度が早い
// foreachよりforの方が参照速度が早い
// 参考文献：https://qiita.com/Fuji0k0/items/c9bad9e04989eefc0393

// 完走した感想
// 自力でここまで持ってくるのすげえな！！！！！
// EnemyをMonoBehaviorにして、いろいろテストした方がわかりやすいかも