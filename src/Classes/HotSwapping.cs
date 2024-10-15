//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace NotEnoughMadness
//{
//    public static class Hotswap
//    {
//        // PROBLEM:
//        // passed things here do NOT get their changes changed in patches.cs
//        // I need to convert these to use the keywords

//        // StatCard_Character
//        public static StatCard_Character StatCard_Character(StatCard_Character inCharacter)
//        {
//            if (inCharacter is null)
//            {
//                Debug.Log("NEM: HOTSWAP CHARACTER IS NULL");
//                return null;
//            }

//            return StatCard_Base.ReturnCardByName<StatCard_Character>(inCharacter.name);
//        }
//        public static void StatCard_Character(List<StatCard_Character> inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Count; i++)
//            {
//                inCharacters[i] = Hotswap.StatCard_Character(inCharacters[i]);
//            }
//        }
//        public static void StatCard_Character(StatCard_Character[] inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Count(); i++)
//            {
//                inCharacters[i] = Hotswap.StatCard_Character(inCharacters[i]);
//            }
//        }

//        // StatCard_Stage_Story.StageCharacterSet
//        public static StatCard_Stage_Story.StageCharacterSet StageCharacterSet(StatCard_Stage_Story.StageCharacterSet inCharacterSet)
//        {
//            if (inCharacterSet is null)
//            {
//                Debug.Log("NEM: HOTSWAP CHARACTERSET IS NULL");
//                return null;
//            }
                 
//            inCharacterSet.MyCharacter = Hotswap.StatCard_Character(inCharacterSet.MyCharacter);
//            inCharacterSet.DefaultLoadout = Hotswap.StatCard_Loadout(inCharacterSet.DefaultLoadout);
//            inCharacterSet.DefaultWardrobe = Hotswap.StatCard_Loadout_Wardrobe(inCharacterSet.DefaultWardrobe);

//            return inCharacterSet;
//        }

//        public static void StageCharacterSet(List<StatCard_Stage_Story.StageCharacterSet> inCharacterSets)
//        {
//            for (int i = 0; i < inCharacterSets.Count; i++)
//            {
//                inCharacterSets[i] = Hotswap.StageCharacterSet(inCharacterSets[i]);
//            }
//        }

//        public static void StageCharacterSet(StatCard_Stage_Story.StageCharacterSet[] inCharacterSets)
//        {
//            for (int i = 0; i < inCharacterSets.Length; i++)
//            {
//                inCharacterSets[i] = Hotswap.StageCharacterSet(inCharacterSets[i]);
//            }
//        }

//        // StatCard_Stage
//        public static StatCard_Stage StatCard_Stage(StatCard_Stage inStage)
//        {
//            if (inStage is null)
//            {
//                Debug.Log("NEM: HOTSWAP STAGE IS NULL");
//                return null;
//            }
                
//           return StatCard_Base.ReturnCardByName<StatCard_Stage>(inStage.name);
//        }
//        public static void StatCard_Stage(List<StatCard_Stage> inStages)
//        {
//            for (int i = 0; i < inStages.Count; i++)
//            {
//                inStages[i] = Hotswap.StatCard_Stage(inStages[i]);
//            }
//        }
//        public static void StatCard_Stage(StatCard_Stage[] inStages)
//        {
//            for (int i = 0; i < inStages.Length; i++)
//            {
//                inStages[i] = Hotswap.StatCard_Stage(inStages[i]);
//            }
//        }

//        //StatCard_Loadout
//        public static StatCard_Loadout StatCard_Loadout(StatCard_Loadout inLoadout)
//        {
//            if (inLoadout is null) return null;

//            return StatCard_Base.ReturnCardByName<StatCard_Loadout>(inLoadout.name);
//        }
//        public static void StatCard_Loadout(List<StatCard_Loadout> inLoadouts)
//        {
//            for (int i = 0; i < inLoadouts.Count; i++)
//            {
//                inLoadouts[i] = Hotswap.StatCard_Loadout(inLoadouts[i]);
//            }
//        }
//        public static void StatCard_Loadout(StatCard_Loadout[] inLoadouts)
//        {
//            for (int i = 0; i < inLoadouts.Length; i++)
//            {
//                inLoadouts[i] = Hotswap.StatCard_Loadout(inLoadouts[i]);
//            }
//        }

//        //StatCard_Loadout_Wardrobe
//        public static StatCard_Loadout_Wardrobe StatCard_Loadout_Wardrobe(StatCard_Loadout_Wardrobe inWardrobe)
//        {
//            if (inWardrobe is null) return null;
            
//            return StatCard_Base.ReturnCardByName<StatCard_Loadout_Wardrobe>(inWardrobe.name);
//        }
//        public static void StatCard_Loadout_Wardrobe(List<StatCard_Loadout_Wardrobe> inWardrobes)
//        {
//            for (int i = 0; i < inWardrobes.Count; i++)
//            {
//                inWardrobes[i] = Hotswap.StatCard_Loadout_Wardrobe(inWardrobes[i]);
//            }
//        }
//        public static void StatCard_Loadout_Wardrobe(StatCard_Loadout_Wardrobe[] inWardrobes)
//        {
//            for (int i = 0; i < inWardrobes.Length; i++)
//            {
//                inWardrobes[i] = Hotswap.StatCard_Loadout_Wardrobe(inWardrobes[i]);
//            }
//        }

//        // WeaponLoadout
//        public static WeaponLoadout WeaponLoadout(WeaponLoadout inWeaponLoadout)
//        {
//            if (inWeaponLoadout is null) return null;

//            inWeaponLoadout.Loadout = Hotswap.StatCard_Loadout(inWeaponLoadout.Loadout);
//            return inWeaponLoadout;
//        }
//        public static void WeaponLoadout(List<WeaponLoadout> inWeaponLoadouts)
//        {
//            for (int i = 0; i < inWeaponLoadouts.Count; i++)
//            {
//                inWeaponLoadouts[i] = Hotswap.WeaponLoadout(inWeaponLoadouts[i]);
//            }
//        }
//        public static void WeaponLoadout(WeaponLoadout[] inWeaponLoadouts)
//        {
//            for (int i = 0; i < inWeaponLoadouts.Length; i++)
//            {
//                inWeaponLoadouts[i] = Hotswap.WeaponLoadout(inWeaponLoadouts[i]);
//            }
//        }

//        // StatCard_Thrown
//        public static StatCard_Thrown StatCard_Thrown(StatCard_Thrown inThrown)
//        {
//            if (inThrown is null) return null;
            
//            return StatCard_Base.ReturnCardByName<StatCard_Thrown>(inThrown.name);
//        }

//        // StatCard_Weapon
//        public static StatCard_Weapon StatCard_Weapon(StatCard_Weapon inWeapon)
//        {
//            if (inWeapon is null) return null;
            
//            return StatCard_Base.ReturnCardByName<StatCard_Weapon>(inWeapon.name);
//        }
//        public static void StatCard_Weapon(List<StatCard_Weapon> inWeapons)
//        {
//            for (int i = 0; i < inWeapons.Count; i++)
//            {
//                inWeapons[i] = Hotswap.StatCard_Weapon(inWeapons[i]);
//            }
//        }
//        public static void StatCard_Weapon(StatCard_Weapon[] inWeapons)
//        {
//            for (int i = 0; i < inWeapons.Length; i++)
//            {
//                inWeapons[i]= Hotswap.StatCard_Weapon(inWeapons[i]);
//            }
//        }


//        // StatCard_Armor
//        public static StatCard_Armor StatCard_Armor(StatCard_Armor inArmor)
//        {
//            if (inArmor is null) return null;
            
//            return StatCard_Base.ReturnCardByName<StatCard_Armor>(inArmor.name);
//        }
//        public static void StatCard_Armor(List<StatCard_Armor> inArmors)
//        {
//            for (int i = 0; i < inArmors.Count; i++)
//            {
//                inArmors[i] = Hotswap.StatCard_Armor(inArmors[i]);
//            }
//        }
//        public static void StatCard_Armor(StatCard_Armor[] inArmors)
//        {
//            for (int i = 0; i < inArmors.Length; i++)
//            {
//                inArmors[i] = Hotswap.StatCard_Armor(inArmors[i]);
//            }
//        }


//        // SingleCharacter
//        public static SingleCharacter SingleCharacter(SingleCharacter inCharacter)
//        {
//            if (inCharacter is null) return null;

//            inCharacter.Throwable = Hotswap.StatCard_Thrown(inCharacter.Throwable);
//            inCharacter.Weapon = Hotswap.StatCard_Weapon(inCharacter.Weapon);
//            Hotswap.StatCard_Armor(inCharacter.Gear);
//            inCharacter.Sidearm = Hotswap.StatCard_Weapon(inCharacter.Sidearm);
//            inCharacter.Type = Hotswap.StatCard_Character(inCharacter.Type);

//            return inCharacter;
//        }
//        public static void SingleCharacter(List<SingleCharacter> inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Count; i++)
//            {
//                inCharacters[i] = Hotswap.SingleCharacter(inCharacters[i]);
//            }
//        }
//        public static void SingleCharacter(SingleCharacter[] inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Length; i++)
//            {
//                inCharacters[i] = Hotswap.SingleCharacter(inCharacters[i]);
//            }
//        }

//        // WaveCharacter
//        public static WaveCharacter WaveCharacter(WaveCharacter inWaveCharacter)
//        {
//            if (inWaveCharacter is null) return null;

//            inWaveCharacter.Type = Hotswap.StatCard_Character(inWaveCharacter.Type);
//            return inWaveCharacter;
//        }
//        public static void WaveCharacter(List<WaveCharacter> inWaveCharacters)
//        {
//            for (int i = 0; i < inWaveCharacters.Count; i++)
//            {
//                inWaveCharacters[i] = Hotswap.WaveCharacter(inWaveCharacters[i]);
//            }
//        }

//        // WaveCharacter_Arena
//        public static WaveCharacter_Arena WaveCharacter_Arena(WaveCharacter_Arena inCharacter)
//        {
//            if (inCharacter is null) return null;
            
//            inCharacter.UnitType = Hotswap.WaveCharacter(inCharacter.UnitType);
//            return inCharacter;
//        }
//        public static void WaveCharacter_Arena(List<WaveCharacter_Arena> inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Count; i++)
//            {
//                inCharacters[i] = Hotswap.WaveCharacter_Arena(inCharacters[i]);
//            }
//        }
//        public static void WaveCharacter_Arena(WaveCharacter_Arena[] inCharacters)
//        {
//            for (int i = 0; i < inCharacters.Length; i++)
//            {
//                inCharacters[i] = Hotswap.WaveCharacter_Arena(inCharacters[i]);
//            }
//        }

//        // WaveSquad
//        public static WaveSquad WaveSquad(WaveSquad inWaveSquad)
//        {
//            if (inWaveSquad is null) return null;

//            Hotswap.SingleCharacter(inWaveSquad.UnitSpawn);
//            return inWaveSquad;
//        }
//        public static void WaveSquad(List<WaveSquad> inWaveSquads)
//        {
//            for (int i = 0; i < inWaveSquads.Count; i++)
//            {
//                inWaveSquads[i] = Hotswap.WaveSquad(inWaveSquads[i]);
//            }
//        }
//        public static void WaveSquad(WaveSquad[] inWaveSquads)
//        {
//            for (int i = 0; i < inWaveSquads.Length; i++)
//            {
//                inWaveSquads[i] = Hotswap.WaveSquad(inWaveSquads[i]);
//            }
//        }

//        // WaveSpawn
//        public static WaveSpawn WaveSpawn(WaveSpawn inWaveSpawn)
//        {
//            if (inWaveSpawn is null) return null;

//            Hotswap.WeaponLoadout(inWaveSpawn.WeaponStock);
//            Hotswap.SingleCharacter(inWaveSpawn.Bosses);
//            Hotswap.WaveSquad(inWaveSpawn.CustomSquads);
//            Hotswap.WaveCharacter(inWaveSpawn.UnitTypes);

//            return inWaveSpawn;
//        }
//        public static void WaveSpawn(List<WaveSpawn> inWaveSpawns)
//        {
//            for (int i = 0; i < inWaveSpawns.Count; i++)
//            {
//                inWaveSpawns[i] = Hotswap.WaveSpawn(inWaveSpawns[i]);
//            }
//        }
//        public static void WaveSpawn(WaveSpawn[] inWaveSpawns)
//        {
//            for (int i = 0; i < inWaveSpawns.Length; i++)
//            {
//                inWaveSpawns[i] = Hotswap.WaveSpawn(inWaveSpawns[i]);
//            }
//        }

//        // Arena_Wave_Sequence
//        public static Arena_Wave_Sequence Arena_Wave_Sequence(Arena_Wave_Sequence inSequence)
//        {
//            if (inSequence is null) return null;

//            Hotswap.SingleCharacter(inSequence.Bosses);
//            Hotswap.WaveCharacter_Arena(inSequence.Units);

//            return inSequence;
//        }
//        public static void Arena_Wave_Sequence(List<Arena_Wave_Sequence> inSequences)
//        {
//            for (int i = 0; i < inSequences.Count; i++)
//            {
//                inSequences[i] = Hotswap.Arena_Wave_Sequence(inSequences[i]);
//            }
//        }
//        public static void Arena_Wave_Sequence(Arena_Wave_Sequence[] inSequences)
//        {
//            for (int i = 0; i < inSequences.Length; i++)
//            {
//                inSequences[i] = Hotswap.Arena_Wave_Sequence(inSequences[i]);
//            }
//        }

//        // Wave_Tandem
//        public static Wave_Tandem Wave_Tandem(Wave_Tandem inTandem)
//        {
//            if (inTandem is null) return null;

//            Hotswap.WaveContainer(inTandem.myWaves);

//            return inTandem;
//        }

//        // WaveContainer
//        public static WaveContainer WaveContainer(WaveContainer inContainer)
//        {
//            if (inContainer is null) return null;

//            inContainer.myTandem = Hotswap.Wave_Tandem(inContainer.myTandem);
//            inContainer.myWaveData = Hotswap.WaveSpawn(inContainer.myWaveData);

//            return inContainer;
//        }
//        public static void WaveContainer(List<WaveContainer> inContainers)
//        {
//            for (int i = 0; i < inContainers.Count; i++)
//            {
//                inContainers[i] = Hotswap.WaveContainer(inContainers[i]);
//            }
//        }

//        // ArmorList
//        public static ArmorList ArmorList(ArmorList inList)
//        {
//            if (inList is null) return null;

//            Hotswap.StatCard_Armor(inList.Armor);

//            return inList;
//        }

//        // UniformWearable
//        public static UniformWearable UniformWearable(UniformWearable inUniform)
//        {
//            if (inUniform is null) return null;

//            inUniform.ArmorPicks = Hotswap.ArmorList(inUniform.ArmorPicks);

//            return inUniform;
//        }
//        public static void UniformWearable(List<UniformWearable> inUniforms)
//        {
//            for (int i = 0; i < inUniforms.Count; i++)
//            {
//                inUniforms[i] = Hotswap.UniformWearable(inUniforms[i]);
//            }
//        }
//        public static void UniformWearable(UniformWearable[] inUniforms)
//        {
//            for (int i = 0; i < inUniforms.Length; i++)
//            {
//                inUniforms[i] = Hotswap.UniformWearable(inUniforms[i]);
//            }
//        }

//        // AnimationClip
//        public static AnimationClip AnimationClip(AnimationClip inClip)
//        {
//            if (inClip is null) return null;
            
//            return Storage_GameAssets.LoadAnim(inClip.name);
//        }

//        // SpawnChatter
//        public static SpawnChatter_Action.SpawnChatter SpawnChatter(SpawnChatter_Action.SpawnChatter inChatter)
//        {
//            if (inChatter is null) return null;

//            inChatter.myAnim = Hotswap.AnimationClip(inChatter.myAnim);

//            return inChatter;
//        }

        
//    }
//}
