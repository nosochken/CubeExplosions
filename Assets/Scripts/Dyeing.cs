using UnityEngine;

public class Dyeing : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}