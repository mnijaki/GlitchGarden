using UnityEngine;
using UnityEngine.UI;

// Options manager.
public class OptionsManager : MonoBehaviour
{
  // Volume slider.
  public Slider volume;
  // Difficulty slider.
  public Slider difficulty;

	// Initialization.
	void Start()
  {
    // Add listener to volume slider.
    this.volume.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    // Get values.
    this.volume.value=PlayerPrefsManager.MasterVolumeGet();
    this.difficulty.value=PlayerPrefsManager.DifficultyGet();
  } // End of Start

  // Saves player preferences.
  public void PlayerPrefsSave()
  {
    // Save values.
    PlayerPrefsManager.MasterVolumeSet(this.volume.value);
    PlayerPrefsManager.DifficultySet((int)this.difficulty.value);
  } // End of PlayerPrefsSave

  // Event - on volume change.
  private void OnVolumeChange()
  {
    MusicManager.Instance.VolumeChange(this.volume.value);
  } // End of OnVolumeChange

  // Set default values.
  public void DefaultsSet()
  {
    // Set values.
    this.volume.value=0.5F;
    this.difficulty.value=1;
  } // End of DefaultsSet

} // End of OptionsManager