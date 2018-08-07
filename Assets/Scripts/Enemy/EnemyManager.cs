using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour {

  public enum WavePattern {
    StraightHorizontal,
    StraightVertical,
    Quadratic,
    Circle
  }

  //敵の生成や出現を管理するクラス

  public float interval = 2;
  public GameObject straightEnemy;
  public GameObject quadraticEnemy;
  public GameObject circleEnemy;
  private GameObject [] SEnemys;
  private GameObject [] QEnemys;
  private GameObject [] CEnemys;

  public WavePattern [] enemyPatterns;

  //private static EnemyManager instance = null;
  private float time;
  private float pass; //intervalごとに出すためのポイント的な
  private int enemyCount = 0; //今何wave目かの目印

  private const int bulletPool = 100;

  /*
  public static EnemyManager Instance {
    get {
      if (instance == null) {
        instance = new EnemyManager ();
      }
      return instance;
    }
    set {

    }
  }

  protected EnemyManager () {

  }
  */

  private void Awake () {
    SEnemys = new GameObject [10];
    QEnemys = new GameObject [10];
    CEnemys = new GameObject [10];
    for (int i = 0; i < 10; i++) {
      SEnemys [i] = CreateEnemy (straightEnemy);
      QEnemys [i] = CreateEnemy (quadraticEnemy);
      CEnemys [i] = CreateEnemy (circleEnemy);
    }
    pass = interval;
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor (time * 10) / 10 == pass) {
      if (enemyCount < enemyPatterns.Length) {
        switch (enemyPatterns [enemyCount].ToString ()) {
        case "StraightHorizontal":
          StraightHorizontal ();
          break;
        case "StraightVertical":
          StraightVertical ();
          break;
        case "Quadratic":
          Quadratic ();
          break;
        case "Circle":
          Circle ();
          break;
        }
        enemyCount++;
        pass += interval;
      }
    }
  }

  public GameObject CreateEnemy (GameObject obj) {
    GameObject enemy;
    enemy = (GameObject)Instantiate (obj);
    enemy.SetActive (false);
    enemy.transform.parent = this.transform;
    return enemy;
  }

  //ここから下は出現させる関数、どの関数も似たようなこと書いてるから改善できそう
  public void StraightHorizontal () {
    int count = 0;
    int number = 3; //何匹出すかの設定
    float x = -2.0f;
    for (int i = 0; i < SEnemys.Length; i++) {
      if (!SEnemys [i].activeSelf) {
        SEnemys [i].transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
        SEnemys [i].SetActive (true);
        x += 2.0f;
        count++;
      }
      if (count >= number) {
        break;
      }
    }
  }

  public void StraightVertical() {
    Debug.Log ("StraightVerticalまだ書いてない！！！");
  }

  public void Quadratic () {
    int count = 0;
    int number = 3;
    float z = 10.0f;
    for (int i = 0; i < QEnemys.Length; i++) {
      if (!QEnemys [i].activeSelf) {
        QEnemys [i].transform.position = new Vector3 (-12, this.transform.position.y, z);
        QEnemys [i].SetActive (true);
        z += 0.8f;
        count++;
      }
      if (count >= number) {
        break;
      }
    }
  }

  public void Circle () {
    int count = 0;
    int number = 1;
    float x = 0.0f;
    for (int i = 0; i < CEnemys.Length; i++) {
      if (!CEnemys [i].activeSelf) {
        CEnemys [i].transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
        CEnemys [i].SetActive (true);
        x += 2.0f;
        count++;
      }
      if (count >= number) {
        break;
      }
    }
  }

}
