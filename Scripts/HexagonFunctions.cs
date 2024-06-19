using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexagonFunctions : MonoBehaviour
{
  [SerializeField] private GameObject[] hexagons;
  [SerializeField] private GameObject[] platforms;
  [SerializeField] private float rotateSpeed;

  [SerializeField] private float visibleTime;

  [SerializeField] private bool clickable;

  private void Start()
  {
    hexagons = GameObject.FindGameObjectsWithTag("Hexagon");
    
    platforms = GameObject.FindGameObjectsWithTag("Platform");

    foreach (GameObject hexagon in hexagons)
    {
      hexagon.SetActive(true);
    }
    
    foreach (GameObject platform in platforms)
    {
      platform.GetComponent<SpriteRenderer>().enabled = false;
    }

    clickable = true;
  }

  private void Update()
  {
    if (clickable)
    {
      foreach (GameObject hexagon in hexagons)
      {
        hexagon.transform.Rotate(0f, 0f, 0.75f);
        hexagon.GetComponent<Image>().color = new Color(0f, 255f, 0f);
      }
    }
    else
    {
      foreach (GameObject hexagon in hexagons)
      {
        hexagon.transform.Rotate(0f,0f,0f);
        hexagon.GetComponent<Image>().color = new Color(255f, 0f, 0f);
      }
    }
    
  }

  public void HexagonFunction()
  {
    Debug.Log("Function Called");

    if (clickable)
    {
      StartCoroutine("ShowPlatforms");
    }
  }

  public IEnumerator ShowPlatforms()
  {
    clickable = false;
    
    foreach (GameObject platform in platforms)
    {
      platform.GetComponent<SpriteRenderer>().enabled = true;
    }

    yield return new WaitForSeconds(visibleTime);
    
    foreach (GameObject platform in platforms)
    {
      platform.GetComponent<SpriteRenderer>().enabled = false;
    }

    yield return new WaitForSeconds(3f);

    clickable = true;
    
    StopCoroutine("ShowPlatforms");
    
  }
  
  
}
