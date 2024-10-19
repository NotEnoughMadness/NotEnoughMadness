using NotEnoughMadness.Classes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    class NEM_Char_DataAssigner : NEM_DataAssigner
    {
        [Space(5f)]
        [Header("Char_DataAssigner")]

        [Tooltip("Assign a serial number TO THE SPAWNED GUY that you can refer to in other components (eg. the event system)")]
        public string assignSerialNumber = "";

        [Tooltip("Control type of the character.")]
        public NEM_ControllerType controllerType = NEM_ControllerType.NPC;

        [Tooltip("If the controller type is player, how do you load the player? \r\n\r\nBy stage is the characters in the stage's statcard (does not apply if you don't launch this scene through the loadout/stage launch menu)\r\nBy save is your last played character on a save file (like in story mode hub worlds)\r\nBy card is what statcard name you input to this data assigner.")]
        public NEM_PlayerLoadType playerLoadType = NEM_PlayerLoadType.ByCard;

        [Tooltip("Where to spawn the character to? If null, it will spawn right on the data assigner point.")]
        public NEM_Person_Repository spawnToEntranceOrVehicle;

        [Tooltip("StatCard_Character name of the character that will spawn.")]
        public string characterType = "AAHW0_Grunt";

        [Tooltip("Override the display name of this bozo. If empty, does not override.")]
        public string displayedName = "";

        [Tooltip("Is the character essential")]
        public bool amEssential = false;

        [Tooltip("Is the character invincible, undying, immortal, etc etc")]
        public bool amInvincible = false;

        [Tooltip("Can it????")]
        public bool canPlayerSquad = false;

        [Tooltip("Is the squadmate permannet?!?!?!??")]
        public bool permanentSquadmate = false;

        [Tooltip("Should the character stay still in place and not move never ever again")]
        public bool fixedInPlace = false;

        [Tooltip("If true, doesn't spawn the dude with his default statcard held weapons.")]
        public bool wipeDefaultHeld = false;

        [Tooltip("Statcard names of weapons held in hand. First weapon is right hand, second is left hand.")]
        public string[] weaponsHeld = new string[2] {"", ""};

        [Tooltip("Statcard names of weapons stowed on the character's back. First weapon is right hand, second is left hand")]
        public string[] weaponsBack = new string[2] {"", ""};

        [Tooltip("Statcard name of the thrown weapon.")]
        public string weaponThrown = "";

        [Tooltip("Statcard names of armor worn by the character.")]
        public string[] armorWorn = new string[1];

        [Tooltip("Uniform is basically armor but you have more control over this stuff.")]
        public NEM_UniformWearable[] uniform = new NEM_UniformWearable[0];

        [Tooltip("Name of the StatCard_Collectible the character will drop upon death.")]
        public string keycardName = "";



        // addToSquad ignore for now mmmmmmmmmmm circular dependencies and runtime creation mmm
        // you'll need a central manager for alllllll of the nem components and youll hav eto init everything from there instead of the components
        [Tooltip("What guys to add to the squad of this guy or reverse idk")]
        public NEM_Char_DataAssigner[] addToSquad = new NEM_Char_DataAssigner[0];

        [Tooltip("I dunno")]
        public bool applyTraitsToExistingCharacters = false;

        [Tooltip("Traits to add to the spawned character in addition to its' statcard's traits.")]
        public List<NEM_TraitList> addTraits = new List<NEM_TraitList>();

        [Tooltip("Behaviors to add to the spawned character in addition to its' statcard's behaviors. ")]
        public List<NEM_BehaviorList> addBehaviors = new List<NEM_BehaviorList>();

        [Tooltip("Modules? What are those?!")]
        public List<string> addModules = new List<string>();

        [Tooltip("What behaviors to remove from the character's default behaviors on spawn?")]
        public List<NEM_BehaviorList> removeBehaviors = new List<NEM_BehaviorList>();

        [Tooltip("What skills to remove from the character's default skills on spawn?")]
        public List<NEM_SkillsList> removeSkills = new List<NEM_SkillsList>();

        [Tooltip("What traits to remove from the character's default traits on spawn?")]
        public List<NEM_TraitList> removeTraits = new List<NEM_TraitList>();

        NEM_Char_DataAssigner()
        {
            MapManager.OnCreateMapComponents += CreateMapComponents;
            MapManager.OnConnectMapComponents += ConnectMapComponents;
        }

        void CreateMapComponents(object sender, EventArgs e)
        {
            Debug.Log("NEM: CreateMapComponents called on " + this.name);
            Char_DataAssigner assigner = gameObject.AddComponent<Char_DataAssigner>();

            assigner.RemoveTraits = new List<TraitList>();
            foreach (NEM_TraitList trait in removeTraits)
            {
                TraitList newTrait = (TraitList)(int)trait;

                assigner.RemoveTraits.Add(newTrait);
            }

            assigner.RemoveSkills = new List<SkillsList>();
            foreach (NEM_SkillsList skill in removeSkills)
            {
                SkillsList newSkill = (SkillsList)(int)skill;

                assigner.RemoveSkills.Add(newSkill);
            }

            assigner.RemoveBehaviors = new List<BehaviorList>();
            foreach (NEM_BehaviorList behavior in removeBehaviors)
            {
                BehaviorList newBehavior = (BehaviorList)(int)behavior;

                assigner.RemoveBehaviors.Add(newBehavior);
            }

            assigner.AddModules = addModules;

            assigner.AddBehaviors = new List<BehaviorList>();
            foreach (NEM_BehaviorList behavior in addBehaviors)
            {
                BehaviorList newBehavior = (BehaviorList)(int)behavior;

                assigner.AddBehaviors.Add(newBehavior);
            }

            assigner.AddTraits = new List<TraitList>();
            foreach (NEM_TraitList trait in addTraits)
            {
                TraitList newTrait = (TraitList)(int)trait;

                assigner.AddTraits.Add(newTrait);
            }

            assigner.amEssential = amEssential;
            assigner.amInvincible = amInvincible;
            assigner.ApplyTraitsToExistingCharacters = applyTraitsToExistingCharacters;

            assigner.AssignSerialNumber = assignSerialNumber;
            assigner.SerialNumber = serialNumber;

            assigner.canPlayerSquad = canPlayerSquad;
            assigner.DisplayedName = displayedName;
            assigner.FixedInPlace = fixedInPlace;

            // Weapons back
            var weaponBackLeft = StatCard_Base.ReturnCardByName<StatCard_Weapon>(weaponsBack[0]);
            var weaponBackRight = StatCard_Base.ReturnCardByName<StatCard_Weapon>(weaponsBack[1]);

            assigner.itemsBack = new StatCard_Weapon[2];
            if (weaponBackLeft) assigner.itemsBack[0] = weaponBackLeft;
            if (weaponBackRight) assigner.itemsBack[1] = weaponBackRight;

            // Weapons held
            var weaponHeldLeft = StatCard_Base.ReturnCardByName<StatCard_Weapon>(weaponsHeld[0]);
            var weaponHeldRight = StatCard_Base.ReturnCardByName<StatCard_Weapon>(weaponsHeld[1]);

            assigner.itemsHeld = new StatCard_Weapon[2];
            if (weaponHeldLeft) assigner.itemsHeld[0] = weaponHeldLeft;
            if (weaponHeldRight) assigner.itemsHeld[1] = weaponHeldRight;

            // Armor worn
            List<StatCard_Armor> wornArmorList = new List<StatCard_Armor>();
            foreach (string armorName in armorWorn)
            {
                StatCard_Armor foundArmor = StatCard_Base.ReturnCardByName<StatCard_Armor>(armorName);
                if (foundArmor == null) continue;

                wornArmorList.Add(foundArmor);
            }

            assigner.itemsWorn = wornArmorList.ToArray();

            // Weapon thrown
            var thrownCard = StatCard_Base.ReturnCardByName<StatCard_Thrown>(weaponThrown);
            if (thrownCard) assigner.itemThrown = thrownCard;

            assigner.myControlType = (Controller_Base.ControllerType)(int)controllerType;

            var keyCard = StatCard_Base.ReturnCardByName<StatCard_Collectible>(keycardName);
            if (keyCard) assigner.myKeycard = keyCard;

            assigner.myPlayerLoad = (Char_DataAssigner.PlayerLoadType)(int)playerLoadType;

            var charType = StatCard_Base.ReturnCardByName<StatCard_Character>(characterType);
            if (charType)
            {
                assigner.myType = charType; 
            } else
            {
                assigner.myType = StatCard_Base.ReturnCardByName<StatCard_Character>("AAHW0_Grunt");
            }

            assigner.PermanentSquadmate = permanentSquadmate;

            List<UniformWearable> uniformList = new List<UniformWearable>();
            foreach(NEM_UniformWearable nemUniform in uniform)
            {
                UniformWearable newUniform = new UniformWearable();
                newUniform.AltMaterialIndex = nemUniform.altMaterialIndex;
                newUniform.AltMeshIndex = nemUniform.altMeshIndex;

                ArmorList armorPicks = new ArmorList();
                foreach(string armorName in nemUniform.armorList)
                {
                    StatCard_Armor foundArmor = StatCard_Base.ReturnCardByName<StatCard_Armor>(armorName);
                    if (foundArmor) armorPicks.Armor.Add(foundArmor);
                }
                newUniform.ArmorPicks = armorPicks;

                newUniform.Glass = nemUniform.glassColor;
                newUniform.Tint = nemUniform.tint1Color;
                newUniform.Tint2 = nemUniform.tint2Color;
            }

            assigner.Uniform = uniformList.ToArray();

            assigner.WipeDefaultHeld = wipeDefaultHeld;


            
        }
        void ConnectMapComponents(object sender, EventArgs e)
        {
            Debug.Log("NEM: ConnectMapComponents called on " + this.name);
            Char_DataAssigner assigner = gameObject.GetComponent<Char_DataAssigner>();

            // ADD TO SQUAD
            List<Char_DataAssigner> convertedAddToSquad = new List<Char_DataAssigner>();

            foreach(NEM_Char_DataAssigner nemAssigner in addToSquad)
            {
                Char_DataAssigner foundAssigner = nemAssigner.gameObject.GetComponent<Char_DataAssigner>();

                if (foundAssigner == null) continue;

                convertedAddToSquad.Add(foundAssigner);

            }

            assigner.addToSquad = convertedAddToSquad.ToArray();

            // SPAWN TO ENTRANCE
            assigner.SpawnToEntranceOrVehicle = spawnToEntranceOrVehicle.gameObject.GetComponent<Person_Repository>();
        }
    }
}
