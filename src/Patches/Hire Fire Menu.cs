using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;
using System;

namespace NotEnoughMadness.Classes
{
    
    //todo: rewrite ALLAT cuz it AINT WORKI N
    // 😱😱😱😱😱😱😱😱😱😱
    /*
    [HarmonyPatch(typeof(Headquarters_Manager), "Event_HireFireScreen")]
    public class NEMHireFireMenu
    {
        public static List<Arena_Manager.StatusQuoSquad.StatusQuoTroop> currentManifest = new List<Arena_Manager.StatusQuoSquad.StatusQuoTroop>();


        [HarmonyPrefix]
        static bool Event_HireFireScreen()
        {
            try
            {
                Color color = new Color(0.7f, 1f, 0.9f);
                Color color2 = new Color(0.7f, 0.8f, 1f);
                Color color3 = new Color(1f, 0.9f, 0.8f);
                Color color4 = new Color(1f, 1f, 0.7f);

                bool flag = Game_Manager.currentCareer.chars_Hired.Count > 0;
                bool flag2 = Game_Manager.currentCareer.chars_ForSale.Count > 0;
                bool flag3 = Game_Manager.currentCareer.arenaStats.Rank_Minion_Level > 1;

                string text = "Want to talk about <color=#" + ColorUtility.ToHtmlStringRGB(color) + ">bringing in new Recruits</color> for hire?";

                text += "\n\n";
                text += (flag2 ? ("You've got a few able <color=#" + ColorUtility.ToHtmlStringRGB(color2) + ">Recruits ready to hire</color>.") : ("We don't currently have any <color=#" + ColorUtility.ToHtmlStringRGB(color2) + ">Recruits ready to hire</color> if you want to hire any."));
                text += "\n\n";
                text += (flag ? ("Or do you wanna <color=#" + ColorUtility.ToHtmlStringRGB(color3) + ">fire a Hireling</color>?") : ("It doesn't look like you've got any <color=#" + ColorUtility.ToHtmlStringRGB(color3) + ">Hirelings</color>\nworking for you yet, boss."));

                Market_Main.CanAfford(Game_Manager.currentCareer, Headquarters_Manager.Cost_RefreshRecruitPool());

                List<UI_MenuButtons.ListButtonInfo> list = new List<UI_MenuButtons.ListButtonInfo>
                {
                    new UI_MenuButtons.ListButtonInfo(new List<string> { "Summon New Recruits", null, null }, new List<Color> { color }, Color.Lerp(color, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(Headquarters_Manager.Event_ClearRecruitPool), null, null, UI_MenuButtons.ButtonStyle.Medium, true),
                    new UI_MenuButtons.ListButtonInfo(new List<string> { "Hire from Recruit Pool", null, null }, new List<Color> { flag2 ? color2 : Color.grey }, Color.Lerp(color2, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(Headquarters_Manager.Event_OpenHireScreen), null, null, UI_MenuButtons.ButtonStyle.Medium, flag2),
                    new UI_MenuButtons.ListButtonInfo(new List<string> { "Fire Your Hirelings", null, null }, new List<Color> { flag ? color3 : Color.grey }, Color.Lerp(color3, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(Headquarters_Manager.Event_OpenFireScreen), null, null, UI_MenuButtons.ButtonStyle.Medium, flag),
                    new UI_MenuButtons.ListButtonInfo(new List<string> { "Contract Minions", null, null }, new List<Color> { flag3 ? color4 : Color.grey }, Color.Lerp(color4, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(NEMHireFireMenu.Event_ChooseAgency), null, null, UI_MenuButtons.ButtonStyle.Medium, true),
                    new UI_MenuButtons.ListButtonInfo(new List<string> { "Hire Special Characters", null, null }, new List<Color> { color4 }, Color.Lerp(color4, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(NEMHireFireMenu.Event_ChooseFaction), null, null, UI_MenuButtons.ButtonStyle.Medium, true)
                };

                UI_MenuButtons ui_MenuButtons = UI_MenuButtons.NewMenu(new List<string> { "Staff Management", text }, null, new List<UI_MenuButtons.ButtonInfo>
                {
                    new UI_MenuButtons.ButtonInfo("Nevermind", null, null, true)
                }, true);

                ui_MenuButtons.AddFeature_List(list, 1);
                ui_MenuButtons.Modify_WidthMin(450);
            } catch(Exception ex)
            {
                Debug.Log("NEM: Error patching Event_HireFireScreen()");
                Debug.Log(ex.ToString());
                Debug.Log(ex.StackTrace);
                
                return true; // run og code
            }
            
            // stop og code from running
            return false;
        }

        public static void Event_ChooseAgency(object inTarget, bool inToggle)
        {
            UI_MenuButtons.CloseCurrentMenu();
            List<UI_MenuButtons.ListButtonInfo> list = new List<UI_MenuButtons.ListButtonInfo>();

            foreach (Factions faction in Enum.GetValues(typeof(Factions)))
            {
                list.Add(new UI_MenuButtons.ListButtonInfo(new List<string> { faction.ToString(), null, null }, new List<Color> { Color.white }, Color.Lerp(Color.white, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(NEMHireFireMenu.Event_OpenContractScreen), null, faction, UI_MenuButtons.ButtonStyle.Medium, true));
            }

            UI_MenuButtons ui_MenuButtons = UI_MenuButtons.NewMenu(new List<string> { "Available Contracts", "Who are we recruiting from, chief?" }, null, new List<UI_MenuButtons.ButtonInfo>
            {
                new UI_MenuButtons.ButtonInfo("Nevermind", null, null, true)
            }, true);

            ui_MenuButtons.AddFeature_List(list, 1);
            ui_MenuButtons.Modify_WidthMin(450);
        }

        public static void Event_OpenContractScreen(object inTarget, bool inToggle)
        {
            Factions factions = (Factions)inTarget;
            List<Char_Data> list = new List<Char_Data>();
            foreach (StatCard_Character statCard_Character in StatCard_Base.ReturnAllCardsByType<StatCard_Character>())
            {
                if (statCard_Character.DefaultFaction == factions)
                {
                    list.Add(Char_Data.CreateCharacter(statCard_Character));
                }
            }
            UI_MenuButtons.CloseCurrentMenu();
            NEMHireFireMenu.currentManifest = new List<Arena_Manager.StatusQuoSquad.StatusQuoTroop>();
            UI_CharSelect.CreateCharSelect(list, 0, "CONTRACT", new UI_CharSelect.CanSelectCharacter(NEMHireFireMenu.CanSelect_AddMinion), new UI_CharSelect.OnSelectCharacter(NEMHireFireMenu.AddMinion), new UI_CharSelect.OnCancelSelect(NEMHireFireMenu.CompleteOrder), new UI_CharSelect.OnFormatCharacter(NEMHireFireMenu.Format_AddMinion), null, true, true);
        }

        public static bool CanSelect_AddMinion(Char_Data inDude)
        {
            return Market_Main.CanAfford(Game_Manager.currentCareer, Market_Main.ReturnHireCost(inDude, false)) && NEMHireFireMenu.currentManifest.Count < Game_Manager.currentCareer.arenaStats.Value_Hireling_SquadMax;
        }

        public static void AddMinion(Char_Data selectedChar)
        {
            if (!Market_Main.AttemptPurchase(Game_Manager.currentCareer, Market_Main.ReturnHireCost(selectedChar, false)))
            {
                return;
            }
            StatCard_Character myCard = selectedChar.myCard;
            NEMHireFireMenu.currentManifest.Add(new Arena_Manager.StatusQuoSquad.StatusQuoTroop
            {
                displayname = myCard.FullName,
                Unit = myCard,
                Loadout = myCard.DefaultLoadout
            });
            UI_ButtonEvents.MenuSound(Audio_Manager.ButtonSounds.BuySell);
            Audio_Manager.PlaySound(myCard.VoiceSet.Affirmative, 2f);
        }

        public static void CompleteOrder()
        {
            if (NEMHireFireMenu.currentManifest.Count > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Arena_Manager.currentManager.Ref_StatusQuo[i] = new Arena_Manager.StatusQuoSquad
                    {
                        GroupName = "Custom Order",
                        Troops = NEMHireFireMenu.currentManifest.ToArray()
                    };
                }

                string text = "Alright Chief, I've reviewed the manifest on our order, they're asking $" + NEMHireFireMenu.ReturnMinionCost().ToString() + " For each deployment.";
                UI_Narration.NarrateLine(Headquarters_Manager.currentManager.BossmanNPC.ReturnMyCreatedChar(), text, VoiceTypes.Affirmative, true);
            }
        }

        public static int ReturnMinionCost()
        {
            int num = 0;
            int num2 = Traverse.Create<Arena_Manager>().Method("ReturnSummonMinionRank").GetValue<int>();
            foreach (Arena_Manager.StatusQuoSquad.StatusQuoTroop statusQuoTroop in Arena_Manager.currentManager.Ref_StatusQuo[num2].Troops)
            {
                num += Market_Main.ReturnBribeCost(statusQuoTroop.Unit);
            }
            return Mathf.FloorToInt((float)num * Mathf.Lerp(1f, (float)(num2 + 1), 0.75f));
        }

        public static void Format_AddMinion(Char_Data inDude, UI_CharSelect inSelectMenu)
        {
            NEMHireFireMenu.Format_PayToAddToManifest(inDude, inSelectMenu, Market_Main.ReturnHireCost(inDude, false));
        }

        private static void Format_PayToAddToManifest(Char_Data inDude, UI_CharSelect inSelectMenu, int inAmount)
        {
            int value_Hireling_SquadMax = Game_Manager.currentCareer.arenaStats.Value_Hireling_SquadMax;
            inSelectMenu.ExtraDetailsText.text = "<color=white>Cost:</color> <size=100>" + (Market_Main.CanAfford(Game_Manager.currentCareer, inAmount) ? "<color=#00DD00>" : "<color=#DD0000>") + TextFormatter.ConvertToDollars(inAmount) + "</color></size>";
        }

        public static void Event_ChooseFaction(object inTarget, bool inToggle)
        {
            UI_MenuButtons.CloseCurrentMenu();
            List<UI_MenuButtons.ListButtonInfo> list = new List<UI_MenuButtons.ListButtonInfo>();

            foreach (Factions faction in Enum.GetValues(typeof(Factions)))
            {
                list.Add(new UI_MenuButtons.ListButtonInfo(new List<string> { faction.ToString(), null, null }, new List<Color> { Color.white }, Color.Lerp(Color.white, Color.black, 0.25f), default(UI_MenuButtons.SpriteInfo), new UI_MenuButtons.ListButtonAction(NEMHireFireMenu.Event_OpenHireSpecialScreen), null, faction, UI_MenuButtons.ButtonStyle.Medium, true));
            }

            UI_MenuButtons ui_MenuButtons = UI_MenuButtons.NewMenu(new List<string> { "Available Contracts", "Who are we recruiting, chief?" }, null, new List<UI_MenuButtons.ButtonInfo>
            {
                new UI_MenuButtons.ButtonInfo("Nevermind", null, null, true)
            }, true);

            ui_MenuButtons.AddFeature_List(list, 1);
            ui_MenuButtons.Modify_WidthMin(450);
        }

        public static void Event_OpenHireSpecialScreen(object inTarget, bool inToggle)
        {
            Factions factions = (Factions)inTarget;
            List<Char_Data> list = new List<Char_Data>();
            foreach (StatCard_Character statCard_Character in StatCard_Base.ReturnAllCardsByType<StatCard_Character>())
            {
                if (statCard_Character.DefaultFaction == factions)
                {
                    list.Add(Char_Data.CreateCharacter(statCard_Character));
                }
            }
            UI_MenuButtons.CloseCurrentMenu();
            UI_CharSelect.CreateCharSelect(list, 0, "HIRE", new UI_CharSelect.CanSelectCharacter(NEMHireFireMenu.CanSelect_HireMinion), new UI_CharSelect.OnSelectCharacter(NEMHireFireMenu.HireMinion), null, new UI_CharSelect.OnFormatCharacter(NEMHireFireMenu.Format_HireMinion), null, true, true);
        }

        public static bool CanSelect_HireMinion(Char_Data inDude)
        {
            return Market_Main.CanAfford(Game_Manager.currentCareer, Market_Main.ReturnHireCost(inDude, true)) && Traverse.Create<Headquarters_Manager>().Method("SpaceToHire").GetValue<bool>();
        }

        private static void HireMinion(Char_Data selectedChar)
        {
            if (!Market_Main.AttemptPurchase(Game_Manager.currentCareer, Market_Main.ReturnHireCost(selectedChar, true)))
            {
                return;
            }
            Career_Data.Hireling_HireRecruit(selectedChar);
            UI_ButtonEvents.MenuSound(Audio_Manager.ButtonSounds.BuySell);
            Audio_Manager.PlaySound(selectedChar.myCard.VoiceSet.Affirmative, 2f);
            UI_CharSelect.RemoveSelectedCharacter();
            if (!selectedChar.ReturnMyCombatant())
            {
                return;
            }
            if (selectedChar.ReturnMyCombatant().currentRepository)
            {
                selectedChar.ReturnMyCombatant().currentRepository.CancelUse(selectedChar.ReturnMyCombatant(), true);
            }
            Headquarters_Manager headquarters_Manager = Headquarters_Manager.currentManager;
            if (headquarters_Manager != null)
            {
                headquarters_Manager.SendHirelingToActivity(selectedChar.ReturnMyCombatant());
            }
            selectedChar.ReturnMyCombatant().myPersonalInterface.myNPCArea.Type = NPC_Area.InteractTypes.Hireling;
            selectedChar.ReturnMyCombatant().myPersonalInterface.myNPCArea.UseEvent = NPC_Area.InteractEvents.NONE;
            selectedChar.ReturnMyCombatant().DeselectObject();
        }

        private static void Format_HireMinion(Char_Data inDude, UI_CharSelect inSelectMenu)
        {
            //Headquarters_Manager.Format_PayToAddToRoster(inDude, inSelectMenu, Market_Main.ReturnHireCost(inDude, true));
            Traverse.Create<Headquarters_Manager>().Method("Format_PayToAddToRoster").GetValue(inDude, inSelectMenu, Market_Main.ReturnHireCost(inDude, true));
        }
    }
    */
}
