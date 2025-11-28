using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, ISkill
{


    private MeshRenderer _mesh;
    private Collider _collider;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }
    public void OnPickup(MovementCar car)
    {
        _mesh.enabled = false;
        _collider.enabled = false;
        ScoreManager.isDoubleScoreActive = true;
        StartCoroutine(SkillDuration());
    }
    public void ActivateSkill(MovementCar car)
    { 
        
    }

    IEnumerator SkillDuration()
    {
        yield return new WaitForSeconds(20f);
        ScoreManager.isDoubleScoreActive = false;
        _mesh.enabled = true;
        _collider.enabled = true;
    }
}
