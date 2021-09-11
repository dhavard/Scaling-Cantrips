﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Properties;
using UnityEngine;

namespace ScalingCantrips
{
    [TypeId("6d0160c8a948402a907e095ed1741702")]
    public class HighestCasterLevel : PropertyValueGetter
    {
    
        public override int GetBaseValue(UnitEntityData unit)
        {
            // this won't be perfect but it will at least be a fix
            // we will go through every non-mythic spellbook and just send back the highest out
            int HighestCasterLevel = 0;
            Main.Log("Checking that we're firing at all.");

            foreach (Spellbook spellbook in unit.Descriptor.Spellbooks)
            {
                Main.Log("Testing spellbook " + spellbook.m_Type);
                Main.Log("Caster Level" + spellbook.CasterLevel.ToString());
                Main.Log("First level" + spellbook.FirstSpellbookLevel.ToString());
                if( HighestCasterLevel < spellbook.CasterLevel && !spellbook.IsMythic)
                    HighestCasterLevel = spellbook.CasterLevel;

            }

            return HighestCasterLevel;
        }
        
       
    }
}