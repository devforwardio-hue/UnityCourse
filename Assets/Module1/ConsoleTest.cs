using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class ConsoleTest : MonoBehaviour
{
  public TextMeshPro debugMessage;
 public string message = "Welcome to Devforward.io! If we got this far, yo mama is - a really cool person, maybe.";
  public int maxMessages = 50;
  private int currentMessages = 0;

  void Start()
  {
    
    StartCoroutine(LogEverySecond());
  }

  void Update()
  {
    debugMessage.text = message;
  }

  IEnumerator LogEverySecond()
  {
    while (currentMessages < maxMessages)
    {
      Debug.Log(message);
      currentMessages++;
      yield return new WaitForSeconds(1f);
    }
  }
}
