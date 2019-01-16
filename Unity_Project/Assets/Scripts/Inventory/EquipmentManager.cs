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

    //public GameObject sword_1;
    //public GameObject sword_2;
    //public GameObject halbert_1;

    private void Start()
    {
        index = System.Enum.GetNames(typeof(Equip_position)).Length;
        currentEquipment = new Equipment[index];
        player_weapons = GameObject.FindGameObjectsWithTag("Kn_w");
        for (int j = 0; j < player_weapons.Length; j++)//check different weapon states
        {
            Debug.Log(player_weapons[j].name);
            player_weapons[j].SetActive(false);
        }
    }

    public void Equip(Equipment newEquipment)
    {
        int equipemt_index_numer = (int)newEquipment.position;//different position index number

        currentEquipment[equipemt_index_numer] = newEquipment;
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
