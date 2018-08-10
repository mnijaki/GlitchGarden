using UnityEngine;

// Manage gravestone.
public class GravestoneManager : MonoBehaviour
{
  // Animator.
  private Animator anim;

  // Initialization.
  private void Start()
  {
    // Get animator.
    this.anim=this.GetComponent<Animator>();
  } // End of Start

  // On collision (graveston rigidbody must have turn off sleep mode).
  private void OnTriggerStay2D(Collider2D collision)
  {
    // Get object from collision.
    GameObject obj = collision.gameObject;
    // If not collision with attacker then exit from function.
    if(!obj.GetComponent<AttackerManager>())
    {
      return;
    }
    // Run animation.
    this.anim.SetTrigger("is_under_attack_trigger");
  } // End of OnTriggerStay2D

} // End of GravestoneManager