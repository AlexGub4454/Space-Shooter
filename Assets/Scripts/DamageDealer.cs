﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    // Start is called before the first frame update
    public int GetDamage() {

        Destroy(gameObject);
        return damage;
    }
}
