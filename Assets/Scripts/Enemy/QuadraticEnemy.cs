using UnityEngine;

public class QuadraticEnemy : Enemy {

  override protected void Awake () {
    base.Awake ();
  }

  override protected void Update () {
    time += Time.deltaTime;
    QuadraticMove (-12, 10, 12, 3);
    base.Update ();
	}

  override protected void OnDisable () {
    base.OnDisable ();
  }

  protected void QuadraticMove (float passing_x, float passing_z, float max_x, float max_z) {
    float a = (passing_x - max_x) / ((passing_z - max_z) * (passing_z - max_z));
    Vector3 pos = this.transform.position;
    pos.z -= enemy_speed;
    pos.x = a * (pos.z - max_z) * (pos.z - max_z) + max_x;
    this.transform.position = pos;
  }

}
