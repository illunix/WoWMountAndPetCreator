using Microsoft.EntityFrameworkCore;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WoWMountAndPetCreator.Infrastructure;
using WoWMountAndPetCreator.Infrastructure.Data;
using WoWMountAndPetCreator.Infrastructure.Entities;

namespace WoWMountAndPetCreator.Pages
{
    public class MountTabViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly ApplicationDbContext _context;
        private bool _isFlyingMount;
        private string _name;
        private string _icon;
        private bool _reins;
        private ItemQuality _itemQuality = ItemQuality.Blue;
        private int _creaturemodelId;

        public MountTabViewModel(
            IWindowManager windowManager,
            ApplicationDbContext context
        )
        {
            _windowManager = windowManager;
            _context = context;
        }

        public bool IsFlyingMount
        {
            get { return _isFlyingMount; }
            set { SetAndNotify(ref _isFlyingMount, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetAndNotify(ref _name, value); }
        }

        public string Icon
        {
            get { return _icon; }
            set { SetAndNotify(ref _icon, value); }
        }

        public bool Reins
        {
            get { return _reins; }
            set { SetAndNotify(ref _reins, value); }
        }

        public IEnumerable<ItemQuality> ItemQualities
        {
            get
            {
                return Enum.GetValues(typeof(ItemQuality)).Cast<ItemQuality>();
            }
        }

        public ItemQuality ItemQuality
        {
            get { return _itemQuality; }
            set { SetAndNotify(ref _itemQuality, value); }
        }
        public int CreatureModelId
        {
            get { return _creaturemodelId; }
            set { SetAndNotify(ref _creaturemodelId, value); }
        }

        public async Task AddMount()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ShowErrorMessageBox("Name cannot be empty!");
            }
            else if (string.IsNullOrEmpty(Icon))
            {
                ShowErrorMessageBox("Icon cannot be empty!");
            }

            var creatureId = (await _context.Creatures
                .Select(q => q.Entry)
                .OrderBy(q => q)
                .LastOrDefaultAsync()) + 1;

            var creature = new Creature(
                Entry: creatureId,
                ModelId1: CreatureModelId,
                Name: Name,
                "Mount Preview",
                MinLevel: 80,
                MaxLevel: 80,
                Faction: 35,
                Speed_Walk: 1,
                Speed_Run: 1,
                Scale: 1,
                BaseVariance: 1,
                RangeVariance: 1,
                Unit_Class: 1,
                Unit_Flags2: 2048,
                Type: 1,
                HoverHeight: 1,
                HealthModifier: 1,
                ManaModifier: 1,
                ArmorModifier: 1,
                DamageModifier: 1,
                ExperienceModifier: 1,
                MovementId: 140,
                RegenHealth: 1,
                Flags_Extra: 2
            );

            _context.Creatures
                .Add(creature);

            var iconFile = @$"Interface\Icons\{Icon}";

            var spellIconId = (await _context.SpellIcons
                .Select(q => q.ID)
                .OrderBy(q => q)
                .LastOrDefaultAsync()) + 1;

            var spellIcon = new SpellIcon(
                spellIconId,
                iconFile
            );

            _context.SpellIcons
                .Add(spellIcon);

            var spellId = (await _context.Spells
                .Select(q => q.ID)
                .OrderBy(q => q)
                .LastOrDefaultAsync()) + 10023;

            var spellDescription = $"Summons and dismisses a {Name}.  ${(IsFlyingMount ? "This is a flying mount." : "This is a very fast mount.")}";
            var spell = new Spell(
                ID: spellId,
                Mechanic: 21,
                Attributes: 269582608,
                AttributesExF: 131072,
                CastingTimeIndex: 16,
                InterruptFlags: 31,
                ProcChance: 101,
                SpellLevel: 80,
                DurationIndex: 21,
                RangeIndex: 1,
                EquippedItemClass: -1,
                Effect_1: 6,
                Effect_2: 6,
                EffectDieSides_2: 1,
                EffectBasePoints_2: 99,
                ImplicitTargetA_1: 1,
                ImplicitTargetA_2: 1,
                EffectAura_1: 78,
                EffectAura_2: 32,
                EffectAura_3: 0,
                EffectMiscValue_1: creatureId, 
                SpellVisualID_1: 1706,
                SpellIconID: spellIconId,
                Name_Lang_enUS: Name,
                Name_Lang_Mask: 16712190,
                NameSubtext_Lang_Mask: 16712172,
                Description_Lang_enUS: spellDescription,
                Description_Lang_Mask: 16712190,
                AuraDescription_Lang_enUS: "Increases speed by $s2%.",
                AuraDescription_Lang_Mask: 16712190,
                StartRecoveryCategory: 330,
                EffectChainAmplitude_1: 1,
                EffectChainAmplitude_2: 1,
                EffectChainAmplitude_3: 1,
                SchoolMask: 1
            );

            _context.Spells
                .Add(spell);

            var itemIconId = (await _context.ItemIcons
                .Select(q => q.ID)
                .OrderBy(q => q)
                .LastOrDefaultAsync()) + 1;

            var itemIcon = new ItemIcon(
                itemIconId,
                Icon
            );

            _context.ItemIcons
                .Add(itemIcon);

            var itemId = (await _context.Items
                .Select(q => q.Entry)
                .OrderBy(q => q)
                .LastOrDefaultAsync()) + 1;

            var itemName = Reins ? $"Reins of the {Name}" : Name;
            var itemDescription = $"Teaches you how to summon {Name}.  {(IsFlyingMount ? "This is a flying mount" : "This is a very fast mount")}.";

            var item = new Item(
                Entry: itemId,
                Class: 15,
                SubClass: 5,
                SoundOverrideSubclass: -1,
                Name: itemName,
                DisplayId: itemIconId,
                Quality: (int)ItemQuality,
                AllowableClass: -1,
                AllowableRace: -1,
                SpellId_1: 55884,
                SpellCharges_1: -1,
                SpellCooldown_1: -1,
                SpellCategory_1: 330,
                SpellCategoryCooldown_1: 3000,
                SpellId_2: spellId,
                SpellTrigger_2: 6,
                Bonding: 1,
                Description: itemDescription,
                Material: 4
            );

            _context.Items
                .Add(item);

            await _context.SaveChangesAsync();

            _windowManager.ShowMessageBox("Successfully Added new Mount!");

            IsFlyingMount = false;
            Name = "";
            Icon = "";
            CreatureModelId = 0;
            Reins = false;

        }

        private void ShowErrorMessageBox(string text)
            => _windowManager.ShowMessageBox(
                text, 
                "Error", 
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
    }
}
