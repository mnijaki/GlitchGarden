using UnityEngine;
using UnityEngine.UI;

// Manage level progress.
public class Progress:MonoBehaviour
{
  // Level duration.
  [Tooltip("Level duration in seconds")]
  [Range(10.0F,3600)]
  public float level_duration = 60.0F;
  // Progress slider.
  private Slider progress;
  // Flag if level is ended.
  public static bool is_level_ended;
  // Audio source.
  private AudioSource audio_source;
  // Win text.
  private GameObject win_txt;

  // Initialization
  void Start()
  {
    // Reset flag 'is_level_ended'.
    is_level_ended=false;
    // Prepare progress slider.
    ProgressPrepare();
    // Prepare audio source.
    AudioSourcePrepare();
    // Prepare win text.
    WinTxtPrepare();
  } // End of Start

  // Prepare progress slider.
  private void ProgressPrepare()
  {
    // Get slider.
    this.progress=this.GetComponent<Slider>();
    // Set slider values.
    this.progress.minValue=0.0F;
    this.progress.maxValue=this.level_duration;
    this.progress.value=0.0F;
  } // End ProgressPrepare

  // Prepare audio source.
  private void AudioSourcePrepare()
  {
    // Get audio source.
    this.audio_source=this.GetComponent<AudioSource>();
  } // End of AudioSourcePrepare

  // Prepare win text.
  private void WinTxtPrepare()
  {
    // Get win text.
    this.win_txt=GameObject.Find("WinTxt");
    // Deactivate win text.
    this.win_txt.SetActive(false);
  } // End of WinTxtPrepare

  // Update (called once per frame).
  void Update()
  {
    // Actualize progress.
    this.progress.value=Time.timeSinceLevelLoad;
    // If level not ended and time of level reached.
    if((!is_level_ended)&&(Time.timeSinceLevelLoad>=this.level_duration))
    {
      // Level win.
      LvlWin();
    }
    // If user pressed escape.
    if(Input.GetKeyDown(KeyCode.Escape))
    {
      // Load main theme clip.
      MusicManager.Instance.ClipPlayWithLoop(MusicManager.Instance.audio_clips[0]);
      // Return to main menu.
      GameObject.FindObjectOfType<LevelManager>().LoadLevelByName("1.0_Main_menu");
    }
  } // End of Update

  // Level win.
  private void LvlWin()
  {
    // Change flag.
    is_level_ended=true;
    // Play level compleated clip.
    this.audio_source.Play();
    // Destroy all tagged objects.
    AllTaggedObjectsDestroy("DestroyOnWin");
    // Show win text.
    this.win_txt.SetActive(true);
    // Change level.
    GameObject.FindObjectOfType<LevelManager>().LoadNextLevelWithDelay(this.audio_source.clip.length);
  } // End LvlWin

  // Destroy all tagged objects.
  private void AllTaggedObjectsDestroy(string name)
  {
    foreach(GameObject obj in GameObject.FindGameObjectsWithTag(name))
    {
      GameObject.Destroy(obj);
    }
  } // End of AllTaggedObjectsDestroy

} // End of Progress