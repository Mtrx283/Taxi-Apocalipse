using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    private MovementCar car;
    private ISkill skill;

    private void Awake()
    {
        car = GetComponent<MovementCar>();
    }
    private void OnJump()
    {
        skill?.ActivateSkill(car);
        skill = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skill"))
        {
            skill = other.GetComponent<ISkill>();
            skill.OnPickup(car);
        }
    }
}