using UnityEngine;

public class CircleEnemy : Enemy {
  private float t = 0.0f;
  private float center_x = -375.0f;
  private float center_y = 600.0f;
  private float stopCenterY = 100.0f;

  override protected void Awake () {
    base.Awake ();
  }

  override protected void Update () {
    time += Time.deltaTime;
    CircleMove (center_x, center_y, 150, t);
    base.Update ();
  }

  override protected void OnDisable () {
    base.OnDisable ();
  }

  protected void CircleMove (float center_x, float center_y, float radius, float t) {
    Vector3 pos = this.transform.position;
    pos.x = center_x + radius * (float)System.Math.Cos (t);
    pos.y = center_y + radius * (float)System.Math.Sin (t);
    this.t += 0.05f;
    if (center_y > stopCenterY) {
      this.center_y -= enemySpeed;
    }
    this.transform.position = pos;
  }

}
