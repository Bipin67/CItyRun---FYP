using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
  public GameObject loadingScene;
  public Slider gameSlider;

  public void LoadScene(int levelIndex)
  {
    
    StartCoroutine(LoadSceneAsynchronously(levelIndex));
  }

  IEnumerator LoadSceneAsynchronously(int levelIndex)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
    loadingScene.SetActive(true);
    while (!operation.isDone)
    {
      Debug.Log(operation.progress);
      gameSlider.value = operation.progress;
      yield return null;
    }

  }

}
 