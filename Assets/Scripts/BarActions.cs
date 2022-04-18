using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarActions : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip bellSound;
    public BarBehaviour barBehaviour;
    public GameObject winText;
    public GameObject[] actionButtons;

    private void Start()
    {
        List<MethodInfo> actions = new List<MethodInfo>
        {
            GetType().GetMethod("Action1") as MethodInfo,
            GetType().GetMethod("Action2") as MethodInfo,
            GetType().GetMethod("Action3") as MethodInfo,
            GetType().GetMethod("Action4") as MethodInfo,
        };
        for (int i=0; i < 6; i++)
        {
            int randActionIndex = Random.Range(0, 3);
            actions[randActionIndex].Invoke(this, null);
            Debug.Log("Made action" + randActionIndex);
        }
    }

    private void genericAction(List<GameObject> affectedElements)
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clickSound);
        foreach (GameObject affectedElement in affectedElements)
        {
            affectedElement.GetComponent<CellSwitch>().isOn = !affectedElement.GetComponent<CellSwitch>().isOn;
        }
    }

    public void Action1()
    {
        List<GameObject> affectedElements = new List<GameObject>();
        affectedElements.Add(barBehaviour.barElements[0]);
        genericAction(affectedElements);
    }

    public void Action2()
    {
        List<GameObject> affectedElements = new List<GameObject>();
        affectedElements.Add(barBehaviour.barElements[1]);
        affectedElements.Add(barBehaviour.barElements[3]);
        affectedElements.Add(barBehaviour.barElements[4]);
        genericAction(affectedElements);
    }

    public void Action3()
    {
        List<GameObject> affectedElements = new List<GameObject>();
        affectedElements.Add(barBehaviour.barElements[2]);
        affectedElements.Add(barBehaviour.barElements[4]);
        genericAction(affectedElements);
    }

    public void Action4()
    {
        List<GameObject> affectedElements = new List<GameObject>();
        affectedElements.Add(barBehaviour.barElements[0]);
        affectedElements.Add(barBehaviour.barElements[4]);
        genericAction(affectedElements);
    }

    public IEnumerator YouWinAction()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(bellSound, 0.5f);
        winText.SetActive(true);
        
        foreach (GameObject actionButton in actionButtons)
        {
            actionButton.SetActive(false);
        }
        yield return new WaitForSeconds(2);
        
    }

    public void PlayAgain()
    {
        StartCoroutine(_PlayAgain());
    }

    IEnumerator _PlayAgain()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
