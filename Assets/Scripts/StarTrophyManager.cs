using UnityEngine;

// Star trophy manager.
public class StarTrophyManager : MonoBehaviour
{
  // Star birth clip.
  public AudioClip star_birth_clip;
  // Star displayer.
  private StarDisplayer star_displayer;

  // Initialization.
  private void Start()
  {
    this.star_displayer=GameObject.FindObjectOfType<StarDisplayer>();
  } // End of Start

  // Add stars.
  public void StarsAdd(int amount)
  {
    this.star_displayer.StarsAdd(amount);
  } // End of StarsAdd

  // Play star birth clip.
  private void StarBithClipPlay()
  {
    // Play clip.
    AudioSource.PlayClipAtPoint(this.star_birth_clip,this.transform.position);
  } // End of StarBithClipPlay

} // End of StarTrophyManager
