using UnityEngine;

// Manage health.
public class HealthManager : MonoBehaviour
{
  // Health.
  public int health = 100;
  // Destory sound.
  public AudioClip destroy_clip;
  // Explosion.
  public GameObject explosion;

  // Deal damage.
  public void DamageDeal(int damage)
  {
    // Decrease health.
    this.health-=damage;
    // If health below 1.
    if(this.health<1)
    {
      // Destroy object.
      ObjectDestroy();
    }
  } // End of DamageDeal

  // Destory object.
  public void ObjectDestroy()
  {
    // Play destroy sound.
    AudioSource.PlayClipAtPoint(this.destroy_clip,this.transform.position);
    // Instantiate explosion.
    Instantiate(this.explosion,this.transform.position,this.transform.rotation);
    // Destroy object.
    Destroy(this.gameObject);
  } // End of ObjectDestroy

} // End of HealthManager