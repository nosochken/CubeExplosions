using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceOfDivision = 100;

    public float ChanceOfDivision => _chanceOfDivision;

    public void Initialize(Vector3 scale, float chanceOfDivision)
    {
        gameObject.transform.localScale = scale;
        _chanceOfDivision = chanceOfDivision;
    }
}