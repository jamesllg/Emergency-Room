using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationText : MonoBehaviour
{
    public float lifetime;
    private Text t;

    // Use this for initialization
    void Start()
    {
        t = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string text)
    {
        
        gameObject.SetActive(true);
        t.text = text;
        StopAllCoroutines();
        StartCoroutine(TextAppear());
    }

    IEnumerator TextAppear()
    {

        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
}
