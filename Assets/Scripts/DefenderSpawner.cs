using UnityEngine;

// Spawn defender.
public class DefenderSpawner : MonoBehaviour
{
  // Parent of defender.
  private GameObject defender_parent;
  // Star displayer.
  private StarDisplayer star_displayer;

  // Initialization.
  private void Start()
  {
    // Find defender parent(defenders container).
    DefenderParentFind();
    // Get star displayer.
    this.star_displayer=GameObject.FindObjectOfType<StarDisplayer>();
  } // End of Start

  // Find defender parent(defenders container).
  private void DefenderParentFind()
  {
    // Get defenders container.
    this.defender_parent=GameObject.Find("Defenders");
    // If no defender container.
    if(this.defender_parent==null)
    {
      // Create defender container.
      this.defender_parent=new GameObject("Defenders");
    }
  } // End of DefenderParentFind

  // On mouse down.
  private void OnMouseDown()
  {
    // If level has ended then exit from function.
    if(Progress.is_level_ended)
    {
      return;
    }
    // If player can buy defender(use stars).
    if(this.star_displayer.StarsUse(Button.sel_defender.cost_in_stars)==StarDisplayer.UseStatus.SUCCESS)
    {
      // Instantiate defender.
      Instantiate(Button.sel_defender,TilePosGet(),Quaternion.identity,this.defender_parent.transform);
    }
  } // End of OnMouseDown

  // Returns tile position.
  private Vector3 TilePosGet()
  {
    // Convert screen position to world position.
    Vector3 pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // Round positions ('z' is set to 0 because other objects like defenders and attackers are all on z=0).
    pos.x=Mathf.RoundToInt(pos.x);
    pos.y=Mathf.RoundToInt(pos.y);
    pos.z=0;
    // Return value.
    return pos;
  } // End of TilePosGet

} // End of DefenderSpawner