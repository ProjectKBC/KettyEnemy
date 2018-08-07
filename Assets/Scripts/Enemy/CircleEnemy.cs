using UnityEngine;

public class CircleEnemy : Enemy {
  private float t = 0.0f;
  private float center_x = 0.0f;
  private float center_z = 20.0f;
  
  override protected void Awake () {
    base.Awake ();
  }

  override protected void Update () {
    time += Time.deltaTime;
    CircleMove (center_x, center_z, 3, t);
    base.Update ();
  }

  override protected void OnDisable () {
    base.OnDisable ();
  }

  protected void CircleMove (float center_x, float center_z, float radius, float t) {
    Vector3 pos = this.transform.position;
    pos.x = center_x + radius * (float) System.Math.Cos (t);
    pos.z = center_z + radius * (float) System.Math.Sin (t);
    this.t += 0.05f;
    if (center_z > 3) {
      this.center_z -= enemy_speed;
    }
    this.transform.position = pos;
  }

}
