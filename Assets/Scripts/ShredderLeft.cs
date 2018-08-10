using UnityEngine;

// Left shredder.
public class ShredderLeft: MonoBehaviour
{
  // On collision.
  private void OnTriggerEnter2D()
  {
    // Go to lose screen.
    GameObject.FindObjectOfType<LevelManager>().LoadLevelByName("1.4_Lose");
  } // End of OnTriggerEnter2D

} // End of ShredderLeft