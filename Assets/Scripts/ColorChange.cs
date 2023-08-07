using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient rainbowGradient;
    public float duration = 5.0f; // ��������� ���� ������� (� ��������)
    private float t = 0.0f; // �������� ��� ���� �������
    private Renderer renderer; // ��������� �� ��������� Renderer
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

        t += Time.deltaTime; // �������� ��� ����
        float lerp = Mathf.PingPong(t, duration) / duration; // ���������� ��������� ������� ���� ������� (�� 0 �� 1)
        Color color = rainbowGradient.Evaluate(lerp); // ��������� ������� � ���䳺���
        renderer.material.color = color; // ���� ������� ��������
        }
        else
        {
            renderer.material.color = defaultColor;
        }
    }

}
