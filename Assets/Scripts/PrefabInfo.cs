using UnityEngine;
using UnityEngine.UI;

// Show info about animal.
public class PrefabInfo: MonoBehaviour
{
  // Prefab.
  public GameObject prefab;

  // Initialization.
  private void Start()
  {
    // Set values.
    this.transform.Find("Name").GetComponent<Text>().text=this.prefab.name;
    if(this.prefab.GetComponent<AttackerManager>()!=null)
    {
      this.transform.Find("Type").GetComponent<Text>().text="Attacker";
      this.transform.Find("SpawnRate").GetComponent<Text>().text=(1/this.prefab.GetComponent<AttackerManager>().seconds_to_spawn).ToString("F3");
      //this.transform.Find("Speed").GetComponent<Text>().text="---";
      this.transform.Find("ProjectileSpeed").GetComponent<Text>().text="---";
      this.transform.Find("ProjectileDmg").GetComponent<Text>().text="---";
    }
    else
    {
      this.transform.Find("Type").GetComponent<Text>().text="Defender";
      this.transform.Find("SpawnRate").GetComponent<Text>().text="---";
      this.transform.Find("Speed").GetComponent<Text>().text="---";
      //this.transform.Find("FireRate").GetComponent<Text>().text;
      if(this.prefab.GetComponent<DefenderFireManager>()!=null)
      {
        ProjectileManager pm = this.prefab.GetComponent<DefenderFireManager>().projectile.GetComponent<ProjectileManager>();
        this.transform.Find("ProjectileSpeed").GetComponent<Text>().text=pm.speed.ToString();
        this.transform.Find("ProjectileDmg").GetComponent<Text>().text=pm.damage.ToString();
      }
      else
      {
        this.transform.Find("ProjectileSpeed").GetComponent<Text>().text="---";
        this.transform.Find("ProjectileDmg").GetComponent<Text>().text="---";
      }
    }
    this.transform.Find("Health").GetComponent<Text>().text=this.prefab.GetComponent<HealthManager>().health.ToString();

  } // End of Start

} // End of PrefabInfo