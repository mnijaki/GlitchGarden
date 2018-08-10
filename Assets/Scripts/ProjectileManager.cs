using UnityEngine;

// Manage projectile.
[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileManager : MonoBehaviour
{
  // Speed.
  public float speed = 1.0F;
  // Damage.
  public int damage = 10;
	
	// Update (called once per frame).
	void Update()
  {
    // Move.
    Move();
  } // End of Update

  // Move.
  private void Move()
  {
    this.transform.Translate(Vector3.right*this.speed*Time.deltaTime);
  } // End of Move

  // On collision.
  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Get object from collision.
    GameObject obj = collision.gameObject;
    // If not collision with attacker then exit from function.
    if(!obj.GetComponent<AttackerManager>())
    {
      return;
    }
    // Get health component.
    HealthManager health = collision.gameObject.GetComponent<HealthManager>();
    // If no health component then exit from function.
    if(health==null)
    {
      return;
    }
    // Deal damage.
    health.DamageDeal(this.damage);
    // Destroy projectile.
    Destroy(this.gameObject);
  } // End of OnTriggerEnter2D

} // End of ProjectileManager
