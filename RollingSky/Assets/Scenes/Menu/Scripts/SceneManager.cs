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

  public RawImage LoadScreen1;
  public RawImage LoadScreen2;
  public RawImage LoadScreen3;

  private int scene;

  void onAwake() {
    Music.clip = BackGroundMusic;
    Select.clip = SelectSound;
    Music.Play(0);
  }

  public void ChangeScene(string name) {
    Music.Pause();
    Select.Play(0);
    if(name == "Scene_01") LoadScreen1.transform.localScale = new Vector3(1,1,1);
    if(name == "Scene_02") LoadScreen2.transform.localScale = new Vector3(1,1,1);
    if(name == "Scene_03") LoadScreen3.transform.localScale = new Vector3(1,1,1);

    StartCoroutine(waiter(name));
  }

  IEnumerator waiter(string name)
  {
    yield return new WaitForSeconds(5);
    if(name == "Scene_01") UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_01", LoadSceneMode.Single);
    if(name == "Scene_02") UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_02", LoadSceneMode.Single);
    if(name == "Scene_03") UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_03", LoadSceneMode.Single);
  }


  public void Quit() {
     Application.Quit();
  }
}
