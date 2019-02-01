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
    private GameObject[] player_shields;

    public delegate void ChangeEuipment(Equipment newitem, Equipment olditem);
    public ChangeEuipment changeEquipment;

    private void Start()
    {
        index = System.Enum.GetNames(typeof(Equip_position)).Length;
        currentEquipment = new Equipment[index];//initial all position in a arrays
        player_weapons = GameObject.FindGameObjectsWithTag("Kn_w");
        player_shields = GameObject.FindGameObjectsWithTag("Kn_s");
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

        for (int i = 0; i < player_shields.Length; i++)//check different weapon states
        {
            if (player_shields[i].name == "Paladin_J_Nordstrom_Shield")
            {
                player_shields[i].SetActive(true);
            }
            else
            {
                player_shields[i].SetActive(false);
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
        Update_newEquipment(equipemt_index_numer);

    }

    public void Update_newEquipment(int position_index)
    {
        string equipmentName = currentEquipment[position_index].name;

        if (position_index == 0)
        {
            if (currentEquipment[position_index] != null)
            {
                for (int i = 0; i < player_weapons.Length; i++)//check different weapon states
                {
                    player_weapons[i].SetActive(false);
                    if (player_weapons[i].name == equipmentName)
                    {
                        player_weapons[i].SetActive(true);
                    }
                }
            }
        }
        else if (position_index == 1)
        {
            if (currentEquipment[position_index] != null)
            {
                for (int j = 0; j < player_shields.Length; j++)//check different shield states
                {
                    player_shields[j].SetActive(false);
                    if (player_shields[j].name == equipmentName)
                    {
                        player_shields[j].SetActive(true);
                    }
                }
            }
        }
    }
}
