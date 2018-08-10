using UnityEngine;

namespace Ria {
  [System.Serializable]
  public class EnemyManager : MonoBehaviour {
    /*
        public enum ENEMY
        {
            UFA_FIRST,
            UFA_SECOND,
            UFA3_THIRD,

            MAX,
        }

        [SerializeField, Tooltip("")]
        private Vector3 startPosition;
        [SerializeField, Tooltip("タイプ")]
        private ENEMY enemyType = ENEMY.UFA_FIRST;

        [SerializeField, Tooltip("ScriptableObject")]
        private EnemyScriptableObject[] scriptables = new EnemyScriptableObject[(int)ENEMY.MAX];
        [SerializeField, Tooltip("生成数")]
        private int[] caps = new int[(int)ENEMY.MAX];
    
        private ActorPool<EnemyCachedActor> pool = new ActorPool<EnemyCachedActor>();
        private float calcTime = 0;

        protected override void OnInit()
        {
            this.pool.Initialize(0, this.scriptables, this.caps);
            this.pool.Generate();
        }

        protected override void OnRun()
        {
            // スペースキーで一括回収
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.pool.Clear();
            }

            // アクティブなオブジェクト数の更新
            // 呼び出されたフレームで経過時間0 秒で処理されていたものを通常稼動扱いにする
            this.pool.FrameTop();
            float elapsedTime = Time.deltaTime;
            this.calcTime += elapsedTime;

            // とりあえず1 秒毎に発射
            float span = 1f;
            if (this.calcTime >= span)
            {
                EnemyCachedActor enemy = new EnemyCachedActor();
                this.pool.AwakeObject((int)this.enemyType, startPosition, out enemy);
                this.calcTime -= span;
            }

            // アクティブなオブジェクトの更新
            this.pool.Proc(elapsedTime);
        }

        public void OnDestroy()
        {
            this.pool.Final();
        }
        */

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
      float x = -475.0f;
      for (int i = 0; i < SEnemys.Length; i++) {
        if (!SEnemys [i].activeSelf) {
          SEnemys [i].transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
          SEnemys [i].SetActive (true);
          x += 100.0f;
          count++;
        }
        if (count >= number) {
          break;
        }
      }
    }

    public void StraightVertical () {
      Debug.Log ("StraightVerticalまだ書いてない！！！");
    }

    public void Quadratic () {
      int count = 0;
      int number = 3;
      float y = 560.0f;
      for (int i = 0; i < QEnemys.Length; i++) {
        if (!QEnemys [i].activeSelf) {
          QEnemys [i].transform.position = new Vector3 (-780, y, this.transform.position.z);
          QEnemys [i].SetActive (true);
          y += 20.0f;
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
      float x = -375.0f;
      for (int i = 0; i < CEnemys.Length; i++) {
        if (!CEnemys [i].activeSelf) {
          CEnemys [i].transform.position = new Vector3 (x, this.transform.position.y, this.transform.position.z);
          CEnemys [i].SetActive (true);
          x += 100.0f;
          count++;
        }
        if (count >= number) {
          break;
        }
      }
    }
  }
}