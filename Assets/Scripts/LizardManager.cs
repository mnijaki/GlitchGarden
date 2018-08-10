using UnityEngine;

// Manage lizard.
[RequireComponent(typeof(AttackerManager))]
public class LizardManager : MonoBehaviour
{
  // Animator.
  private Animator anim;
  // Attacker.
  private AttackerManager attacker;

  // Initialization.
  void Start()
  {
    // Get animator.
    this.anim=this.GetComponent<Animator>();
    // Get attacker.
    this.attacker=this.GetComponent<AttackerManager>();
  } // End of Start

  // On collision.
  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Get object from collision.
    GameObject obj = collision.gameObject;
    // If not collision with defender then exit from function.
    if(!obj.GetComponent<DefenderManager>())
    {
      return;
    }
    // If defender is behind attacker then exit form function.
    if(obj.transform.position.x>this.transform.position.x-0.5F)
    {
      return;
    }
    // Start attack animation.
    this.anim.SetBool("is_attacking",true);
    // Start attacking.
    this.attacker.Attack(obj);
  } // End of OnTriggerEnter2D

} // End of LizardManager