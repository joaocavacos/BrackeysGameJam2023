using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    //public static List<Ability> abilitiesSelected;
    [SerializeField] private List<Ability> abilitiesSelected;

    public static Caster Instance;

    private void Awake()
    {
        Instance = this;
        
        abilitiesSelected = new List<Ability>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && Time.time > abilitiesSelected[0].nextCastCooldown)
        {
            abilitiesSelected[0].nextCastCooldown = Time.time + abilitiesSelected[0].abilityCooldown;
            abilitiesSelected[0].Cast();
        }

        if(Input.GetKeyDown(KeyCode.R) && Time.time > abilitiesSelected[1].nextCastCooldown){
            abilitiesSelected[1].nextCastCooldown = Time.time + abilitiesSelected[1].abilityCooldown;
            abilitiesSelected[1].Cast();
        }
    }

    public void AddAbility(Ability ability) => abilitiesSelected.Add(ability);

}
