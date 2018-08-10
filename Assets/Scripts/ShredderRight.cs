using UnityEngine;

// Right shredder.
public class ShredderRight: MonoBehaviour
{

  // On collision.
  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Destroy object collided with shredder.
    Destroy(collision.gameObject);
  } // End of OnTriggerEnter2D

} // End of ShredderRight