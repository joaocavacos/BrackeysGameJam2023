using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowStep : Ability
{
    
    [SerializeField] private float stepDistance;
    [SerializeField] private float stepTime;
    [SerializeField] private TrailRenderer trailRenderer;

    public override void Cast(){
        StartCoroutine(Dash());
    }

    private IEnumerator Dash(){
        PlayerController.Instance.transform.position = new Vector2(PlayerController.Instance.transform.position.x + (stepDistance * PlayerController.Instance.transform.localScale.x), PlayerController.Instance.transform.position.y);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(stepTime);
        trailRenderer.emitting = false;
    }
}
