using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
 public static LevelManager instance;
 public GameObject loadingScreen;
 

 private void Awake()
 {
  instance = this;
  SceneManager.LoadSceneAsync((int)SceneIndex.MainScene,LoadSceneMode.Additive);
 }

 public void LoadGame()
 {
  loadingScreen.gameobject.SetActive(true);
  SceneManager.LoadSceneAsync((int)SceneIndex.Menu,LoadSceneMode.Additive);
  SceneManager.LoadSceneAsync((int)SceneIndex.MainScene,LoadSceneMode.Additive);
 }
}
 