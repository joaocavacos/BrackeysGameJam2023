using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private Sprite abilityImage;
    private float nextCast;

    public float abilityCooldown { get { return cooldown; } set { cooldown = value; } }
    public float nextCastCooldown { get { return nextCast; } set { nextCast = value; } }
    public Sprite AbilityImage { get { return abilityImage; } set { abilityImage = value; } }

    public abstract void Cast();
    
    protected void Start()
    {
        Caster.Instance.AddAbility(this);
    }
}
