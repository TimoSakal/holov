using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient rainbowGradient;
    public float duration = 5.0f; // тривалість зміни кольорів (у секундах)
    private float t = 0.0f; // поточний час зміни кольорів
    private Renderer renderer; // посилання на компонент Renderer
    public Color defaultColor;
   public bool makeChanging = false;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(makeChanging == true)
        {

        t += Time.deltaTime; // збільшити час зміни
        float lerp = Mathf.PingPong(t, duration) / duration; // обчислення поточного відсотка зміни кольорів (від 0 до 1)
        Color color = rainbowGradient.Evaluate(lerp); // отримання кольору з градієнта
        renderer.material.color = color; // зміна кольору матеріалу
        }
        else
        {
            renderer.material.color = defaultColor;
        }
    }

}
