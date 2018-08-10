using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
// Display and manage stars counter.
public class StarDisplayer : MonoBehaviour
{
  // Counter.
  [Tooltip("Number of stars")]
  [Range(0,5000)]
  public int counter=100;
  // Text component.
  private Text txt;
  // Enumaration of aviable statuses, when player try to use stars.
  public enum UseStatus { SUCCESS, FAILURE }

	// Initialization.
	void Start()
  {
    // Set text component.
    this.txt=this.GetComponent<Text>();
    // Set text.
    this.txt.text=this.counter.ToString();
  } // End of Start

  // Add stars.
  public void StarsAdd(int amount)
  {
    // Actualize counter.
    this.counter+=amount;
    // Set text.
    this.txt.text=this.counter.ToString();
  } // End of StarsAdd

  // Delete stars.
  public void StarsDel(int amount)
  {
    // Actualize counter.
    this.counter-=amount;
    // Set text.
    this.txt.text=this.counter.ToString();
  } // End of StarsDel

  // Use stars (for buying defenders)
  public UseStatus StarsUse(int amount)
  {
    // If there was no enough stars then return FAILURE status.
    if(this.counter<amount)
    {
      return UseStatus.FAILURE;
    }
    // Delete stars.
    StarsDel(amount);
    // Return SUCCESS status.
    return UseStatus.SUCCESS;
  } // End of StarsUse

} // End of StarDisplayer