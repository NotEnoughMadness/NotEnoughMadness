using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NotEnoughMadness
{
    public class SpawnFriends
    {
        public static bool SpawnFriend_Done()
        {
            /*Char_Data newData = null;
            List<Entrance_Base> list = new List<Entrance_Base>(Cam_Main.currentRoom.myEntrances).FindAll((Entrance_Base o) => !o.disableSpawn);
            Squad_Main squad_Main = Squad_Main.CreateSquad(Factions.None);
            foreach (object obj in InteractiveMode.currentInteractive.allUnitSpawns)
            {
                if (obj.GetType().IsAssignableFrom(typeof(StatCard_Character)))
                {
                    newData = Char_Data.CreateCharacter(obj as StatCard_Character);
                }
                else if (obj.GetType().IsAssignableFrom(typeof(Char_Data)))
                {
                    newData = Saves_Manager.DeepClone<Char_Data>((Char_Data)obj);
                    Char_Data.ConvertFromStorage(newData, ((Char_Data)obj).myCareer, false);
                }
                if (newData != null)
                {
                    List<Entrance_Base> list2 = list;
                    Predicate<Entrance_Base> predicate;
                    if ((predicate = <> 9__1) == null)
                    {
                        predicate = (<> 9__1 = (Entrance_Base o) => o.ReturnMeetVocationRequirements(newData));
                    }
                    List<Entrance_Base> list3 = list2.FindAll(predicate);
                    Entrance_Base entrance_Base = ((list3.Count > 0) ? list3 : list).RandomElement<Entrance_Base>();
                    Wave_Generator.AssignAllDefaultWeapons(newData, 0);
                    if (!newData.ReturnHoldingAnyItem() && newData.myWeaponPreference != WeaponCategories.None && newData.myWeaponPreference != WeaponCategories.Unarmed)
                    {
                        List<StatCard_Weapon> list4 = Catalog_Weapons.ReturnWaveWeapons_ArenaOnly(newData.myLevel - 3, newData.myLevel + 3);
                        if (list4.Count > 0)
                        {
                            newData.HoldItem(0, 0, list4.RandomElement<StatCard_Weapon>().GenerateMe() as Item_Data_Held);
                        }
                    }
                    Combatant_Base combatant_Base = Spawn_Manager.SpawnCharacterToEntrance(newData, entrance_Base, Controller_Base.ControllerType.NPC);
                    squad_Main.AddMember(combatant_Base.myData);
                    Controller_Base.SetAlertStatus(combatant_Base.myController, AI_Wakeup.AlertStatus.Combat);
                }
            }
            InteractiveMode.currentInteractive.allUnitSpawns.Clear();*/
            return true;
        }

        public static void CreateMenu_SpawnFriend()
        {
            Traverse interactiveTraverse = Traverse.Create<InteractiveMode>().Field("currentInteractive");
            interactiveTraverse.Field("allUnitSpawns").SetValue(new List<StatCard_Character>());
            interactiveTraverse.Field("selectedUnitSpawn").SetValue(null);

            List<UI_MenuButtons.ButtonInfo> list = new List<UI_MenuButtons.ButtonInfo>
            {
                new UI_MenuButtons.ButtonInfo("Add Friend", new UI_MenuButtons.ButtonAction(InteractiveMode.UnitSpawn_Add), new UI_MenuButtons.ButtonInteractiveCheck(InteractiveMode.Return_UnitSpawn_CanAdd), true),
                new UI_MenuButtons.ButtonInfo("SPAWN!", new UI_MenuButtons.ButtonAction(SpawnFriend_Done), new UI_MenuButtons.ButtonInteractiveCheck(InteractiveMode.Return_UnitSpawn_CanSpawn), true)
            };

            UI_MenuButtons ui_MenuButtons = UI_MenuButtons.NewMenu(new List<string> { "Spawn Friends", "Select a character and click <color=red>Add Friend</color>, and then click <color=red>SPAWN!</color> to add them to your Squad." }, null, list, true);
            StatCard_Textures statCard_Textures = StatCard_Base.ReturnCardByName<StatCard_Textures>("UI_SquadIcons");

            List<UI_MenuButtons.ListButtonInfo> list2 = new List<UI_MenuButtons.ListButtonInfo>();
            foreach (StatCard_Character statCard_Character in StatCard_Base.ReturnAllCardsByType<StatCard_Character>())
            {
                Sprite sprite = ((statCard_Character.DefaultFaction == Factions.TwoShoes) ? statCard_Textures.Sprites1[1] : statCard_Textures.Sprites1[0]);
                Color color = Color.Lerp(Color.white, Color.red, (float)statCard_Character.Level / 20f);

                UI_MenuButtons.ListButtonInfo listButtonInfo = new UI_MenuButtons.ListButtonInfo(new List<string>
                {
                    string.Concat(new object[]
                    {
                        statCard_Character.FullName,
                        "  <size=16><i><color=-red>",
                        (statCard_Character.DefaultFaction == Factions.TwoShoes) ? Factions.Player : statCard_Character.DefaultFaction,
                        "</color></i></size>"
                    }),
                    "[" + statCard_Character.DefaultFaction.ToString() + "]"
                }, null, new UI_MenuButtons.SpriteInfo(sprite, color), new UI_MenuButtons.ListButtonAction(InteractiveMode.UnitSpawn_Select), null, statCard_Character, UI_MenuButtons.ButtonStyle.Small, true);
                
                list2.Add(listButtonInfo);
            }
            ui_MenuButtons.AddFeature_CloseButton(true);
            ui_MenuButtons.AddFeature_List(list2, 1);
        }

        public static void Event_SpawnFriends()
        {
            CreateMenu_SpawnFriend();
        }
    }
}
