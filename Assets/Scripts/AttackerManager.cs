using UnityEngine;

// Manage attacker.
[RequireComponent(typeof(Rigidbody2D))]
public class AttackerManager : MonoBehaviour
{
  // Spawn rate.
  [Tooltip ("Spawn rate of attacker")]
  [Range(0.5F,300.0F)]
  public float seconds_to_spawn=5.0F;
  // Movment speed.
  private float move_speed = 0.0F;
  // Target.
  private GameObject target;
  // Animator.
  private Animator anim;

  // Initialization.
  private void Start()
  {
    // Get animator.
    this.anim=this.GetComponent<Animator>();
  } // End of Start

  // Update (called once per frame).
  void Update()
  {
    // Move attacker.
    Move();
    // If no target.
    if(this.target==null)
    {
      this.anim.SetBool("is_attacking",false);
    }
  } // End of Update

  // Move attacker.
  private void Move()
  {
    this.transform.Translate(Vector3.left*this.move_speed*Time.deltaTime);
  } // End of Move

  // Set move speed.
  public void MoveSpeedSet(float speed)
  {
    this.move_speed=speed;
  } // End of MoveSpeedSet

  // Strike target (called from animator at the time of actual strike).
  public void AttackStrike(int damage)
  {
    // If no target then exit from function.
    if(this.target==null)
    {
      return;
    }
    // Get health component.
    HealthManager health = this.target.GetComponent<HealthManager>();
    // If no health component then exit from function.
    if(health==null)
    {
      return;
    }
    // Deal damage
    health.DamageDeal(damage);
  } // End of AttackStrike

  // Attack.
  public void Attack(GameObject obj)
  {
    // Set current target.
    this.target=obj;
  } // End of Attack

} // End of AttackerManager