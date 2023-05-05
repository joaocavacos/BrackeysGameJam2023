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

    public float abilityCooldown { get => cooldown;
        set => cooldown = value;
    }
    public float nextCastCooldown { get => nextCast;
        set => nextCast = value;
    }
    public string AbilityName { get => abilityName;
        set => abilityName = value;
    }
    public string AbilityDescription { get => abilityDescription;
        set => abilityDescription = value;
    }
    public Sprite AbilityImage { get => abilityImage;
        set => abilityImage = value;
    }
    public Button AbilityPickBtn { get => abilityPickBtn;
        set => abilityPickBtn = value;
    }

    public abstract void Cast();
    
    protected void Start()
    {
        AbilityManager.Instance.AddAbility(this);
    }
}
