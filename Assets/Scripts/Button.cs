using UnityEngine;
using UnityEngine.UI;

// Button handling.
public class Button : MonoBehaviour
{
  // Defender.
  public DefenderManager defender_prefab;
  // Selected defender.
  public static DefenderManager sel_defender;
  // Buttons array.
  private Button[] btns;

  // Initialization
  private void Start()
  {
    // Get array of buttons.
    this.btns=GameObject.FindObjectsOfType<Button>();
    // If button holds ‘Cactus’ prefab.
    if(this.defender_prefab.name=="Cactus")
    {
      // Select defender.
      sel_defender=this.defender_prefab;
      // Change color of button.
      this.GetComponent<SpriteRenderer>().color=Color.white;
    }
    // Set cost text.
    this.GetComponentInChildren<Text>().text=this.defender_prefab.cost_in_stars.ToString();
  } // End of Start

  // On mouse down.
  private void OnMouseDown()
  {
    // Loop over buttons.
    foreach(Button btn in this.btns)
    {
      btn.GetComponent<SpriteRenderer>().color=Color.black;
    }
    // Change color of clicked button
    this.GetComponent<SpriteRenderer>().color=Color.white;
    // Actualize secelced defender.
    Button.sel_defender=this.defender_prefab;
  } // End of OnMouseDown

} // End of Button