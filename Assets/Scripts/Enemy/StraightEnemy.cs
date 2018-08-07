using System.Collections.Generic;
using UnityEngine;

public class StraightEnemy : Enemy {
  protected const int bulletPool = 10;

  private void Awake () {
    hp = fix_hp;
    time = 0.0f;
    nomal_bullets = new List<GameObject>();
    for (int i = 0; i < bulletPool; i++) {
      nomal_bullets.Add (CreateBullet (nomal_bullet));
    }
    pass = interval;
  }

  public void OnDisable () {
    hp = fix_hp;
    time = 0.0f;
    pass = interval;
  }

	void Update () {
    time += Time.deltaTime;
    Straight ();
    if (Mathf.Floor (time * 10) / 10 == pass) {
      BulletAppear ();
      pass += interval;
    }
    Dead ();
    NomalAttack ();
    BeyondLine ();
	}

  public void Straight () {
    this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - enemy_speed);
  }
}
