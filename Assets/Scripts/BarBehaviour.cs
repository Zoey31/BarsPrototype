using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehaviour : MonoBehaviour
{
    public GameObject barElementPrefab;
    public int barElementNo;

    public List<GameObject> barElements;
    public BarActions actions;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i=0; i < barElementNo; i++)
        {
            barElements.Add(Instantiate(barElementPrefab, transform.position, Quaternion.identity, transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        int noActive = 0;
        foreach (GameObject barElement in barElements)
        {
            if (barElement.GetComponent<CellSwitch>().isOn)
                noActive++;
        }
        if (noActive == barElementNo)
        {
            StartCoroutine(actions.YouWinAction());
        }
    }
}
