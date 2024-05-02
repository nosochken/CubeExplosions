using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceOfBreaking = 100;

    public float ChanceOfBreaking => _chanceOfBreaking;

    public void Initialize(Vector3 scale, float chanceOfBreaking)
    {
        transform.localScale = scale;
        _chanceOfBreaking = chanceOfBreaking;
    }

    public Cube Clone()
    {
        return Instantiate(this);
    }
}