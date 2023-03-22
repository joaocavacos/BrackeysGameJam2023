using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float startPos;
    private float spriteLength;
    [SerializeField] private Transform _camera;
    [SerializeField] private float parallaxFactor;


    void Start()
    {
        startPos = transform.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float tempDistance = (_camera.position.x * (1 - parallaxFactor));
        float distance = (_camera.position.x * parallaxFactor);

        transform.position = new Vector3(startPos + distance, transform.position.y);

        if(tempDistance > startPos + spriteLength) startPos += spriteLength;
        else if(tempDistance < startPos - spriteLength) startPos -= spriteLength;
    }
}
