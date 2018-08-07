using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour {

  public enum WavePattern {
    Horizontal,
    Vertical
  }

  //敵の生成や出現を管理するクラス

  public GameObject straightEnemy;
  public GameObject quadraticEnemy;
  private GameObject [] SEnemys;
  private GameObject [] QEnemys;
  public WavePattern [] enemyPatterns; //出方を記憶するenum配列

  public float speed = 0.1f;
  public float interval = 2;

  private static EnemyManager instance = null;
  private float time;
  private float pass;
  private int patternCount;
  private int enemy_init = 100;

  private const int bulletPool = 100;

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

  private void Awake () {
    SEnemys = new GameObject [10];
    QEnemys = new GameObject [10];
    for (int i = 0; i < 10; i++) {
      SEnemys [i] = CreateEnemy (straightEnemy);
      //QEnemys [i] = CreateEnemy (quadraticEnemy);
    }
    pass = interval;
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor (time * 10) / 10 == pass) {
      MoveStraight ();
      pass += interval;
    }
  }

  public GameObject CreateEnemy (GameObject obj) {
    GameObject enemy;
    enemy = (GameObject)Instantiate (obj);
    enemy.SetActive (false);
    enemy.transform.parent = this.transform;
    return enemy;
  }

  public void MoveStraight () {
    int count = 0;
    float x = -2.0f;
    for (int i = 0; i < SEnemys.Length; i ++) {
      if (!SEnemys[i].activeSelf) {
        SEnemys[i].transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
        SEnemys [i].SetActive (true);
        x += 2.0f;
        count++;
      }
      if (count >= 3) {
        break;
      }
    }
  }

}
