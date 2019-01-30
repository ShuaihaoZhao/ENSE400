using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    private int index;
    private GameObject[] player_weapons;

    public delegate void ChangeEuipment(Equipment newitem, Equipment olditem);
    public ChangeEuipment changeEquipment;

    private void Start()
    {
        index = System.Enum.GetNames(typeof(Equip_position)).Length;
        currentEquipment = new Equipment[index];//initial all position in a arrays
        player_weapons = GameObject.FindGameObjectsWithTag("Kn_w");
        for (int j = 0; j < player_weapons.Length; j++)//check different weapon states
        {
            if (player_weapons[j].name == "Paladin_J_Nordstrom_Sword")
            {
                player_weapons[j].SetActive(true);
            }
            else
            {
                player_weapons[j].SetActive(false);
            }
        }
    }

    public void Equip(Equipment newEquipment)
    {
        int equipemt_index_numer = (int)newEquipment.position;//different position index number
        Equipment oldEquipment = null;

        if (currentEquipment[equipemt_index_numer] == null)
        {
            currentEquipment[equipemt_index_numer] = newEquipment;
        }
        else
        {
            oldEquipment = currentEquipment[equipemt_index_numer];
            currentEquipment[equipemt_index_numer] = newEquipment;
        }
        
        if (changeEquipment != null)
        {
            changeEquipment.Invoke(newEquipment,oldEquipment);
        }
        Update_newEquipment();

    }

    public void Update_newEquipment()
    {
        for (int i = 0; i < index; i++)//check all equipment position
        {
            if (currentEquipment[i] != null)
            {
                string equipmentName = currentEquipment[i].name;
                for (int j = 0; j < player_weapons.Length; j++)//check different weapon states
                {
                    player_weapons[j].SetActive(false);
                    if (player_weapons[j].name == equipmentName)
                    {
                        player_weapons[j].SetActive(true);
                    }
                }

            }
        }
    }
}
