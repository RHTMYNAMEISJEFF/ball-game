using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorScript : MonoBehaviour
{
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        List<Color> color1= new List<Color> { Color.red, Color.blue, Color.green, Color.cyan };

        if (transform.name.Equals("Player"))
        {
            Color randomColor = color1[Random.Range(0, color1.Count)];
            GetComponent<Renderer>().material.color = randomColor;
        }

        if (!transform.childCount.Equals(0))
        {
            foreach(GameObject item in obstacles)
            {
                Color randomColor = color1[Random.Range(0, color1.Count)];
                item.GetComponent<Renderer>().material.color = randomColor;
                color1.Remove(randomColor);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
