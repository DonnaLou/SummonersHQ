using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SummonersHQ
{
    public static class MasteryTextInfo
    {
        public const string OffenseTitle = "offense";

        #region masteryTitles
        public const string Util_SummonersInsight = "Summoner's Insight";
        public const string Util_Wanderer = "Wanderer";
        public const string Util_Meditation = "Meditation";
        public const string Util_ImprovedRecall = "Improved Recall";
        public const string Util_Scout = "Scout";
        public const string Util_Mastermind = "Mastermind";
        public const string Util_ExpandedMind = "Expanded Mind";
        public const string Util_Artificier = "Artificer";
        public const string Util_Greed = "Greed";
        public const string Util_RunicAffinity = "Runic Affinity";
        public const string Util_Vampirism = "Vampirism";
        public const string Util_Biscuiteer = "Biscuiteer";
        public const string Util_Wealth = "Wealth";
        public const string Util_Awareness = "Awareness";
        public const string Util_StrengthOfSpirit = "Strength of Spirit";
        public const string Util_Explorer = "Explorer";
        public const string Util_Pickpocket = "Pickpocket";
        public const string Util_Intelligence = "Intelligence";
        public const string Util_Nimble = "Nimble";
    
        public const string Offense_SummonersWrath = "Summoner's Wrath";
        public const string Offense_Fury = "Fury";
        public const string Offense_Sorcery = "Sorcery";
        public const string Offense_Butcher = "Butcher";
        public const string Offense_Deadliness = "Deadliness";
        public const string Offense_Blast = "Blast";
        public const string Offense_Destruction = "Destruction";
        public const string Offense_Havoc = "Havoc";
        public const string Offense_WeaponExpertise = "Weapon Expertise";
        public const string Offense_ArcaneKnowledge = "Arcane Knowledge";
        public const string Offense_Lethality = "Lethality";
        public const string Offense_BruteForce = "Brute Force";
        public const string Offense_MentalForce = "Mental Force";
        public const string Offense_Spellsword = "Spellsword";
        public const string Offense_Frenzy = "Frenzy";
        public const string Offense_Sunder = "Sunder";
        public const string Offense_Archmage = "Archmage";
        public const string Offense_Executioner = "Executioner";        public const string Defense_SummonersResolve = "Summoner's Resolve";
        public const string Defense_Perseverance = "Perseverance";
        public const string Defense_Durability = "Durability";
        public const string Defense_ToughSkin = "Tough Skin";
        public const string Defense_Hardiness = "Hardiness";
        public const string Defense_Resistance = "Resistance";
        public const string Defense_BladedArmor = "Bladed Armor";
        public const string Defense_Unyielding = "Unyielding";
        public const string Defense_Relentless = "Relentless";
        public const string Defense_VeteransScar = "Veteran's Scars";
        public const string Defense_Safeguard = "Safeguard";
        public const string Defense_Block = "Block";
        public const string Defense_Tenacious = "Tenacious";
        public const string Defense_Juggernaut = "Juggernaut";        public const string Defense_Defender = "Defender";
        public const string Defense_LegendaryArmor = "Legendary Armor";
        public const string Defense_GoodHands = "Good Hands";
        public const string Defense_ReinforcedArmor = "Reinforced Armor";
        public const string Defense_HonorGuard = "Honor Guard";

        #endregion

        #region masteryDescription
        public const string OffenseDesc_SummonersWrath = "Summoner's Wrath: Exhaust lowers target's MR/Armor by 10; Ignite gives +5 AD/AP when on cooldown; Ghost now grants 35% movement speed; Garrison now grants 50% splash damage to allied towers.";
        public const string OffenseDesc_Fury = "Fury: Grants 1 / 2 / 3 / 4% attack speed.";
        public const string OffenseDesc_Sorcery = "Sorcery: Grants 1 / 2 / 3 / 4 cooldown reduction.";
        public const string OffenseDesc_Butcher = "Butcher: Basic attacks deal 2 / 4 bonus damage to minions and monsters.";
        public const string OffenseDesc_Deadliness = "Deadliness: Grants 3 / 6 / 9 / 12 AD at level 18 (.17 AD per rank per level)";
        public const string OffenseDesc_Blast = "Blast: Grants 4.5 / 9 / 13.5 / 18 AP at level 18 (.25 AP per rank per level)";
        public const string OffenseDesc_Destruction = "Destruction: Increases damage to turrets by 5%.";
        public const string OffenseDesc_Havoc = "Havoc: Increases damage by 0.67 / 1.33 / 2%.";
        public const string OffenseDesc_WeaponExpertise = "Weapon Expertise: Grants 8% armor pen.";
        public const string OffenseDesc_ArcaneKnowledge = "Arcane Knowledge: Grants 8% magic pen.";
        public const string OffenseDesc_Lethality = "Lethality: Grants 2.5 / 5% critical strike damage (doubled on melee champions).";
        public const string OffenseDesc_BruteForce = "Brute Force: Grants 1.5 / 3 attack damage.";
        public const string OffenseDesc_MentalForce = "Mental Force: Grants 2 / 4 / 6 ability power.";
        public const string OffenseDesc_Spellsword = "Spellsword: Your basic attacks deal bonus magic damage equal to 5% of your ability power.";
        public const string OffenseDesc_Frenzy = "Frenzy: Grants 10% attack speed for 2 seconds after landing a critical strike.";
        public const string OffenseDesc_Sunder = "Sunder: Grants 2 / 3.5 / 5 armor pen.";
        public const string OffenseDesc_Archmage = "Archmage: Grants 1.25 / 2.5 / 3.75 / 5% increased ability power.";
        public const string OffenseDesc_Executioner = "Executioner: Increases damage by 5% against targets below 50% health (excluding true damage).";

        public const string UtilDesc_SummonersInsight = "Summoner's Insight: Revive grants bonus health for 120 seconds after reviving; Teleport's cast time is reduced to 3.5 seconds; Flash's cooldown is reduced by 15 seconds; Clarity restores 25% bonus mana; Clairvoyance grants persistent sight of enemies revealed for 5 seconds.";
        public const string UtilDesc_Wanderer = "Wanderer: Grants 0.66 / 1.33 / 2% movement speed when out of combat.";
        public const string UtilDesc_Meditation = "Meditation: Grants 1 / 2 / 3 mana regen.";
        public const string UtilDesc_ImprovedRecall = "Improved Recall: Reduces cast time of Recall by 1 second and Enhanced Recall by 0.5 seconds.";
        public const string UtilDesc_Scout = "Scout: Wards see for 25% further for the first 5 seconds.";
        public const string UtilDesc_Mastermind = "Mastermind: Reduces the cooldown of Summoner Spells by 4 / 7 / 10%.";
        public const string UtilDesc_ExpandedMind = "Expanded Mind: Grants 72 / 144 / 216 mana at level 18 (+4 per rank per level)";
        public const string UtilDesc_Artificier = "Artificer: The cooldown of activatable items are reduced by 7.5 / 15%.";
        public const string UtilDesc_Greed = "Greed: Grants 0.5 / 1 / 1.5 / 2 gold per 10 seconds.";
        public const string UtilDesc_RunicAffinity = "Runic Affinity: Increases shrine, relic and neutral buff durations by 20%.";
        public const string UtilDesc_Vampirism = "Vampirism: Grants 1 / 2 / 3% life steal and spell vamp.";
        public const string UtilDesc_Biscuiteer = "Biscuiteer: You start the game with a Total Biscuit of Rejuvenation, that restores 80 health and 50 mana over 10 seconds.";
        public const string UtilDesc_Wealth = "Wealth: Increases starting gold by 25 / 50.";
        public const string UtilDesc_Awareness = "Awareness: Increases experience earned by 1.25 / 2.5 / 3.75 / 5%.";
        public const string UtilDesc_StrengthOfSpirit = "Strength of Spirit: Grants 1 / 2 / 3 bonus health regen for every 400 mana you have.";
        public const string UtilDesc_Explorer = "Explorer: On Summoner's Rift, you start the game with an Explorer's Ward, that places an invisible ward that lasts for 60 seconds. On other maps: you gain +25 starting gold.";
        public const string UtilDesc_Pickpocket = "Pickpocket: Your attacks against enemy champions grant gold (+3 ranged attacks; +5 melee attacks). 5 second cooldown.";
        public const string UtilDesc_Intelligence = "Intelligence: Grants 2 / 4 / 6 % cooldown reduction.";
        public const string UtilDesc_Nimble = "Nimble: Grants 3% movement speed.";

        public const string DefenseDesc_SummonersResolve = "Summoner's Resolve: Increases the duration of Cleanse's crowd control reduction to 4 seconds; Heal passively grants the champion +5 health per level; Smite grants 10 gold on use; Barrier shields for 20 bonus damage."; 
        public const string DefenseDesc_Perseverance = "Perseverance: Grants up to 2 / 4 / 6 health regen based on missing health."; 
        public const string DefenseDesc_Durability = "Durability: Grants 27 / 54 / 81 / 108 health at level 18 (1.5 health per rank per level)";
        public const string DefenseDesc_ToughSkin = "Tough Skin: Reduces damage from monsters by 1 / 2."; 
        public const string DefenseDesc_Hardiness = "Hardiness: Grants 2 / 3.5 / 5 armor."; 
        public const string DefenseDesc_Resistance = "Resistance: Grants 2 / 3.5 / 5 magic resist."; 
        public const string DefenseDesc_BladedArmor = "Bladed Armor: Deals 6 damage to any minion or monster that attacks you."; 
        public const string DefenseDesc_Unyielding = "Unyielding: Reduces damage taken from champions by 1 / 2."; 
        public const string DefenseDesc_Relentless = "Relentless: Reduces the potency of movement slows by 7.5 / 15% (stacks multiplicatively with Boots of Swiftness).";
        public const string DefenseDesc_VeteransScar = "Veteran's Scars: Grants 30 health"; 
        public const string DefenseDesc_Safeguard = "Safeguard: Reduces damage taken from turrets by 5%."; 
        public const string DefenseDesc_Block = "Block: Reduces damage taken from champion basic attacks by 3."; 
        public const string DefenseDesc_Tenacious = "Tenacious: Reduces the duration of crowd control effects by 5 / 10 / 15% (stacks multiplicatively with other sources of crowd control reduction)."; 
        public const string DefenseDesc_Juggernaut = "Juggernaut: Increases you max health by 1.5 / 2.75 / 4%."; 
        public const string DefenseDesc_Defender = "Defender: Grants 1 armor and magic resist for every nearby enemy champion."; 
        public const string DefenseDesc_LegendaryArmor = "Legendary Armor: Increases bonus armor and magic resist by 2 / 3.5 / 5%."; 
        public const string DefenseDesc_GoodHands = "Good Hands: Reduces time spent dead by 10%."; 
        public const string DefenseDesc_ReinforcedArmor = "Reinforced Armor: Reduces damage taken from critical strikes by 10%."; 
        public const string DefenseDesc_HonorGuard = "Honor Guard: Reduce damage taken from all sources by 3%."; 
        #endregion


    
    }
}
