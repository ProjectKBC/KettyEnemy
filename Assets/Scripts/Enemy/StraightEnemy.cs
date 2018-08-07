using UnityEngine;

public class StraightEnemy : Enemy {

  override protected void Awake () {
    base.Awake ();
  }

  override protected void Update () {
    time += Time.deltaTime;
    StraightMove ();
    base.Update ();
	}

  override protected void OnDisable () {
    base.OnDisable ();
  }

  public void StraightMove () {
    this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - enemy_speed);
  }

}
