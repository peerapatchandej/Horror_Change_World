using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChanger : MonoBehaviour
{
  [Header("Target Objects")]
  public GameObject newChange;
  public Transform player;

  [Header("Settings")]
  public float lookAwayThreshold = -0.5f;

  private bool playerPassedTrigger = false;
  private bool worldHasChanged = false;

  private void Awake()
  {
    newChange.SetActive(false);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      playerPassedTrigger = true;
      Debug.Log("Step 1: Player passed trigger. Ready to switch when look away.");
    }
  }

  private void Update()
  {
    if (worldHasChanged || !playerPassedTrigger) return;

    Vector3 directionToTarget = Vector3.Normalize(transform.position - player.position);

    float dot = Vector3.Dot(player.forward, directionToTarget);
    Debug.Log(dot);

    if (dot <= lookAwayThreshold)
    {
      ExecuteChange();
    }
  }

  private void ExecuteChange()
  {
    newChange.SetActive(true);
    worldHasChanged = true;
  }
}
