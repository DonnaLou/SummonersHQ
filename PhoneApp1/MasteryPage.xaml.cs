using System.Windows;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace SummonersHQ
{
    public partial class MasteryPage : PhoneApplicationPage
    {
        public MasteryPage()
        {
            InitializeComponent();
        }

        private void ShowOffenseOverlay(object sender, RoutedEventArgs e)
        {
            TextBlock _img = (TextBlock)sender;

            switch (_img.Tag.ToString())
            {
                case "Wrath":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_SummonersWrath;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_SummonersWrath;
                    break;
                case "Fury":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Fury;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Fury;
                    break;
                case "Sorcery":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Sorcery;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Sorcery;
                    break;
                case "Butcher":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Butcher;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Butcher;
                    break;
                case "Deadliness":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Deadliness;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Deadliness;
                    break;
                case "Blast":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Blast;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Blast;
                    break;
                case "Destruction": 
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Destruction;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Destruction;
                    break;
                case "Havoc":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Havoc;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Havoc;
                    break;
                case "WeaponExp":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Havoc;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Havoc;
                    break;
                case "ArcaneKnow":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_ArcaneKnowledge;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_ArcaneKnowledge;
                    break;
                case "Lethality":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Lethality;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Lethality;
                    break;
                case "BruteForce":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_BruteForce;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_BruteForce;
                    break;
                case "MentalForce":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_MentalForce;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_MentalForce;
                    break;
                case "Spellsword":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Spellsword;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Spellsword;
                    break;
                case "Frenzy":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Frenzy;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Frenzy;
                    break;
                case "Sunder":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Sunder;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Sunder;
                    break;
                case "Archmage":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Archmage;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Archmage;
                    break;
                case "Executioner":
                    this.OffenseTitle.Text = MasteryTextInfo.Offense_Executioner;
                    this.OffenseDesc.Text = MasteryTextInfo.OffenseDesc_Executioner;
                    break;
                default:
                    return;
            }

            OffenseOverlay.Visibility = Visibility.Visible;
        }

        private void ShowUtilityOverlay(object sender, RoutedEventArgs e)
        {
            TextBlock _img = (TextBlock)sender;

            switch (_img.Tag.ToString())
            {
                case "Insight":
                    this.UtilTitle.Text = MasteryTextInfo.Util_SummonersInsight;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_SummonersInsight;
                    break;
                case "Wanderer":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Wanderer;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Wanderer;
                    break;
                case "Mediation":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Meditation;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Meditation;
                    break;
                case "ImprovedRecall":
                    this.UtilTitle.Text = MasteryTextInfo.Util_ImprovedRecall;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_ImprovedRecall;
                    break;
                case "Scout":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Scout;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Scout;
                    break;
                case "Mastermind":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Mastermind;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Mastermind;
                    break;
                case "ExpandedMind":
                    this.UtilTitle.Text = MasteryTextInfo.Util_ExpandedMind;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_ExpandedMind;
                    break;
                case "Artificer":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Artificier;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Artificier;
                    break;
                case "Greed":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Greed;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Greed;
                    break;
                case "RunicAffinity":
                    this.UtilTitle.Text = MasteryTextInfo.Util_RunicAffinity;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_RunicAffinity;
                    break;
                case "Vampirism":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Vampirism;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Vampirism;
                    break;
                case "Biscuiteer":
                    this.UtilTitle.Text = MasteryTextInfo.Defense_Tenacious;
                    this.UtilDesc.Text = MasteryTextInfo.DefenseDesc_Tenacious;
                    break;
                case "Wealth":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Wealth;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Wealth;
                    break;
                case "Awareness":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Awareness;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Awareness;
                    break;
                case "StrengthOfSpirit":
                    this.UtilTitle.Text = MasteryTextInfo.Util_StrengthOfSpirit;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_StrengthOfSpirit;
                    break;
                case "Explorer":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Explorer;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Explorer;
                    break;
                case "Pickpocket":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Pickpocket;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Pickpocket;
                    break;
                case "Intelligence":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Intelligence;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Intelligence;
                    break;
                case "Nimble":
                    this.UtilTitle.Text = MasteryTextInfo.Util_Nimble;
                    this.UtilDesc.Text = MasteryTextInfo.UtilDesc_Nimble;
                    break;
                default:
                    return;
            }

            UtilityOverlay.Visibility = Visibility.Visible;
        }

        private void ShowDefenseOverlay(object sender, RoutedEventArgs e)
        {
            TextBlock _img = (TextBlock)sender;

            switch (_img.Tag.ToString())
            {
                case "Resolve":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_SummonersResolve;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_SummonersResolve;
                    break;
                case "Perseverance":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Perseverance;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Perseverance;
                    break;
                case "Durability":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Durability;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Durability;
                    break;
                case "ToughSkin":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_ToughSkin;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_ToughSkin;
                    break;
                case "Hardiness":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Hardiness;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Hardiness;
                    break;
                case "Resistance":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Resistance;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Resistance;
                    break;
                case "BladedArmor":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_BladedArmor;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_BladedArmor;
                    break;
                case "Unyielding":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Unyielding;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Unyielding;
                    break;
                case "Relentless":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Relentless;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Relentless;
                    break;
                case "VeteransScar":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_VeteransScar;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_VeteransScar;
                    break;
                case "Block":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Block;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Block;
                    break;
                case "Tenacious":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Tenacious;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Tenacious;
                    break;
                case "Juggernaut":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Juggernaut;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Juggernaut;
                    break;
                case "Defender":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_Defender;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_Defender;
                    break;
                case "LegendaryArmor":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_LegendaryArmor;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_LegendaryArmor;
                    break;
                case "GoodHands":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_GoodHands;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_GoodHands;
                    break;
                case "ReinforcedArmor":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_ReinforcedArmor;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_ReinforcedArmor;
                    break;
                case "HonorGuard":
                    this.DefenseTitle.Text = MasteryTextInfo.Defense_HonorGuard;
                    this.DefenseDesc.Text = MasteryTextInfo.DefenseDesc_HonorGuard;
                    break;
                default:
                    return;
            }

            DefenseOverlay.Visibility = Visibility.Visible;

        }

        private void CloseOverlay(object sender, GestureEventArgs e)
        {
            Grid _img = (Grid)sender;
            this.DefenseTitle.Text = _img.Tag.ToString();

            switch (_img.Tag.ToString())
            {
                case "Off":
                    OffenseOverlay.Visibility = Visibility.Collapsed;
                    break;
                case "Def":
                    DefenseOverlay.Visibility = Visibility.Collapsed;
                    break;
                case "Util":
                    UtilityOverlay.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Menu.xaml?id=3", UriKind.Relative));
        }
    }
}