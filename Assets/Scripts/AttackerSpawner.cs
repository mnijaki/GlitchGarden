using UnityEngine;

// Spawn attacker.
public class AttackerSpawner : MonoBehaviour
{
  // Spawn rate of this attacker spawner.
  [Tooltip("Spawn rate multiplier, higher mean that more attackers will spawn")]
  [Range(1,50)]
  public int spawn_rate=1;
  // Array of attackers.
  public AttackerManager[] atackers;
	
	// Update (called once per frame).
	void Update()
  {
    // Loop over array of attackers.
		foreach(AttackerManager attacker in this.atackers)
    {
      // If it is time to spawn this attacker.
      if(IsTimeToSpawn(attacker))
      {
        // Instantiate attacker.
        Instantiate(attacker,this.transform);
      }
    }
  } // End of Update

  // Return information if is time to spawn passed attacker.
  private bool IsTimeToSpawn(AttackerManager attacker)
  {
    // Compute spawns per second.
    float spawns_per_second=1/attacker.seconds_to_spawn;
    // Time.deltaTime guarantee that when FPS will drop down then propability
    // of launching projectile will go up. Calculation is dividied by 5 becouse there is 
    // 5 lanes of attackers.
    return (Random.value < ((Time.deltaTime*spawns_per_second*this.spawn_rate + (PlayerPrefsManager.DifficultyGet()/10)) / 5));
  } // End of IsTimeToSpawn

} // End of AttackerSpawner