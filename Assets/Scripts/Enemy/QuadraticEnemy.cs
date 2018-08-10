using UnityEngine;

public class QuadraticEnemy : Enemy {

  override protected void Awake () {
    base.Awake ();
  }

  override protected void Update () {
    time += Time.deltaTime;
    QuadraticMove (-780.0f, 560.0f, -50.0f, 250.0f);
    base.Update ();
  }

  override protected void OnDisable () {
    base.OnDisable ();
  }

  protected void QuadraticMove (float passing_x, float passing_y, float max_x, float max_y) {
    float a = (passing_x - max_x) / ((passing_y - max_y) * (passing_y - max_y));
    Vector3 pos = this.transform.position;
    pos.y -= enemySpeed;
    pos.x = a * (pos.y - max_y) * (pos.y - max_y) + max_x;
    this.transform.position = pos;
  }

}
