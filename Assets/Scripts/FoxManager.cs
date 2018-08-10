﻿using UnityEngine;

// Manage fox.
[RequireComponent(typeof(AttackerManager))]
public class FoxManager : MonoBehaviour
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
    if(obj.transform.position.x>this.transform.position.x)
    {
      return;
    }
    // If collision with gravestone.
    if(obj.GetComponent<GravestoneManager>())
    {
      // Run trigger (starts jump animation).
      this.anim.SetTrigger("jump_trigger");
    }
    // If not collision with gravestone.
    else
    {
      // Start attack animation.
      this.anim.SetBool("is_attacking",true);
      // Start attacking.
      this.attacker.Attack(obj);
    }
  } // End of OnTriggerEnter2D

} // End of FoxManager