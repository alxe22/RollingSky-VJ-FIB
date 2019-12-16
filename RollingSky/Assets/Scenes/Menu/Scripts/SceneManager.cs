using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

  public AudioClip BackGroundMusic;
  public AudioSource Music;
  public AudioClip SelectSound;
  public AudioSource Select;

  void onAwake() {
    Music.clip = BackGroundMusic;
    Select.clip = SelectSound;
    Music.Play(0);
  }

  public void ChangeScene(string name) {
    Music.Pause();
    Select.Play(0);
    UnityEngine.SceneManagement.SceneManager.LoadScene(name, LoadSceneMode.Single);
  }

}
