using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Barrier : MonoBehaviour
{
    private void Start()
    {
        MakeInvisibleForRaycast();
    }

    private void MakeInvisibleForRaycast()
    {
        int raycastIgnoreNumber = 2;

        gameObject.layer = raycastIgnoreNumber;

        foreach(Transform childTransform in gameObject.transform)
            childTransform.gameObject.layer = raycastIgnoreNumber;
    }
}