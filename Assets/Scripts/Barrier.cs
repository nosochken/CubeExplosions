using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void Start()
    {
        MakeInvisibleForRaycast();
    }

    private void MakeInvisibleForRaycast()
    {
        gameObject.layer = 2;

        foreach(Transform childTransform in gameObject.transform)
            childTransform.gameObject.layer = 2;
    }
}