using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;

namespace NotEnoughMadness.MapMaking
{
    class NEM_Char_DataAssigner : NEM_DataAssigner
    {
        [Space(5f)]
        [Header("Char_DataAssigner")]

        [Tooltip("Assign a serial number that you can refer to in other components (eg. the event system)")]
        public string serialNumber = "";

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
        public NEM_UniformWearable uniform = new NEM_UniformWearable();

        [Tooltip("Name of the StatCard_Collectible the character will drop upon death.")]
        public string keycardName = "";



        // addToSquad ignore for now mmmmmmmmmmm circular dependencies and runtime creation mmm
        // you'll need a central manager for alllllll of the nem components and youll hav eto init everything from there instead of the components

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

        void Awake()
        {
            Char_DataAssigner assigner = gameObject.AddComponent<Char_DataAssigner>();
            assigner.RemoveTraits = new List<TraitList>();
            foreach (NEM_TraitList trait in removeTraits) {
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

            assigner.ApplyTraitsToExistingCharacters = applyTraitsToExistingCharacters;

            assigner.myType = StatCard_Base.ReturnCardByName<StatCard_Character>(characterType);

            assigner.myControlType = (Controller_Base.ControllerType)(int)controllerType;
            assigner.myPlayerLoad = (Char_DataAssigner.PlayerLoadType)(int)playerLoadType;
            assigner.DisplayedName = displayedName;
            assigner.canPlayerSquad = canPlayerSquad;
        }
    }
}
