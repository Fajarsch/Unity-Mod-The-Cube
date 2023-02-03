using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan };
    private int colorIndex = 0;

    private float delayTimeColor = 1;
    private float repeatTimeColor = 0.2f;

    public float delayScale = 1;
    public float repeatScale = 1;

    public float delayPos = 2;
    public float repeatPos = 2;

    void Start()
    {
        InvokeRepeating("ChangeColor", delayTimeColor, repeatTimeColor);
        InvokeRepeating("ChangeScale", delayScale, repeatScale);
        InvokeRepeating("ChangePosition", delayPos, repeatPos);

        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 10.0f * Time.deltaTime);
    }

    void ChangeColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        Renderer.material.color = colors[colorIndex];
    }

    void ChangeScale()
    {
        transform.localScale = Vector3.one * Random.Range(2.5f, 5.0f);
    }

    void ChangePosition()
    {
        float randomPosX = Random.Range(-20.0f, 20.0f);
        float randomPosY = Random.Range(-5.0f, 5.0f);
        float randomPosZ = Random.Range(-10.0f, 10.0f);

        transform.position = new Vector3(randomPosX, randomPosY, randomPosZ);
    }
}
