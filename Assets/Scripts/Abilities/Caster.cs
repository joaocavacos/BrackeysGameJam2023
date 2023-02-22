using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour, ISerializationCallbackReceiver
{
    public static List<Ability> abilitiesSelected;
    [SerializeField] private List<Ability> showAbilities; //used to serialize the abilityList

    private void Awake()
    {
        abilitiesSelected = new List<Ability>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > abilitiesSelected[0].nextCastCooldown)
        {
            abilitiesSelected[0].nextCastCooldown = Time.time + abilitiesSelected[0].abilityCooldown;
            abilitiesSelected[0].Cast();
        }
    }

    public void OnBeforeSerialize()
    {
        showAbilities = abilitiesSelected;
    }

    public void OnAfterDeserialize()
    {
        abilitiesSelected = showAbilities;
    }

}
