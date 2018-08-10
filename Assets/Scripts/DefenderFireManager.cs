using UnityEngine;

// Manage fire of defender.
public class DefenderFireManager: MonoBehaviour
{
  // Projectile.
  public ProjectileManager projectile;
  // Parent of projectile.
  private GameObject projectile_parent;
  // Gun.
  public GameObject gun;
  // Animator.
  private Animator anim;
  // Atacker spawner on the opposite side of defender.
  private AttackerSpawner atacker_spawner;

  // Initialization.
  private void Start()
  {
    // Find projectile parent(projectiles container).
    ProjectileParentFind();
    // Find animator.
    AnimatorFind();
    // Find attacker spawner.
    AttackerSpawnerFind();
  } // End of Start

  // Find projectile parent(projectiles container). 
  private void ProjectileParentFind()
  {
    // Get projectiles container.
    this.projectile_parent=GameObject.Find("Projectiles");
    // If no projectile container.
    if(this.projectile_parent==null)
    {
      // Create projectile container.
      this.projectile_parent=new GameObject("Projectiles");
    }
  } // End of ProjectileParentFind

  // Find animator.
  private void AnimatorFind()
  {
    // Set animator.
    this.anim=this.GetComponent<Animator>();
    // If no animator then log warning.
    if(this.anim==null)
    {
      Debug.LogWarning("No animator found in the defender");
    }
  } // End of AnimatorFind

  // Find attacker spawner.
  private void AttackerSpawnerFind()
  {
    // Loop over each attacker spawners.
    foreach(AttackerSpawner spawner in GameObject.FindObjectsOfType<AttackerSpawner>())
    {
      // If spawner is in lane of defender.
      if(spawner.transform.position.y==this.transform.position.y)
      {
        // Set attacker spawner.
        this.atacker_spawner=spawner;
        // Break.
        break;
      }
    }
    // If no attacker spawner in lane then log warning.
    if(this.atacker_spawner==null)
    {
      Debug.LogWarning("No attacker spawner found in the lane");
    }
  } // End of AttackerSpawnerFind

  // Update.
  private void Update()
  {
    // Manage animation of defender.
    AnimManage();
  } // End of Update

  // Manage animation of defender.
  private void AnimManage()
  {
    // Set animation parameter.
    this.anim.SetBool("is_attacking",IsAttackerInLane());
  } // End of AnimManage

  // Return information if there is attacker in lane.
  private bool IsAttackerInLane()
  {
    // If no attackers in spawner then return FALSE.
    if(this.atacker_spawner.transform.childCount<1)
    {
      return false;
    }
    // Loop over attackers in spawner.
    foreach(Transform attacker_trans in this.atacker_spawner.transform)
    {
      // If attacker is ahead of defender then return TRUE.
      if(attacker_trans.position.x>this.transform.position.x)
      {
        return true;
      }
    }
    // There was no attackers ahead of defender, so return FALSE.
    return false;
  } // End of IsAttackerInLane

  // Fire (called form animation).
  private void Fire()
  {
    // Instantiate projectile.
    Instantiate(this.projectile,this.gun.transform.position,Quaternion.identity,this.projectile_parent.transform);
  } // End of Fire

} // End of DefenderFireManager