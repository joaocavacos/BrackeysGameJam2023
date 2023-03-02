using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private Sprite abilityImage;
    [SerializeField] private Button abilityPickBtn;
    [SerializeField] private string abilityName;
    [SerializeField] private string abilityDescription;
    private float nextCast;

    public float abilityCooldown { get { return cooldown; } set { cooldown = value; } }
    public float nextCastCooldown { get { return nextCast; } set { nextCast = value; } }
    public string AbilityName { get { return abilityName; } set { abilityName = value; } }
    public string AbilityDescription { get { return abilityDescription; } set { abilityDescription = value; } }
    public Sprite AbilityImage { get { return abilityImage; } set { abilityImage = value; } }
    public Button AbilityPickBtn { get { return abilityPickBtn; } set { abilityPickBtn = value; } }

    public abstract void Cast();
    
    protected void Start()
    {
        AbilityManager.Instance.AddAbility(this);
    }
}
