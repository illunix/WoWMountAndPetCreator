using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWMountAndPetCreator.Infrastructure.Entities
{
    public record Spell(
        int ID,
        int Mechanic,
        int Attributes,
        int AttributesExF,
        int CastingTimeIndex,
        int InterruptFlags,
        int ProcChance,
        int DurationIndex,
        int SpellLevel,
        int RangeIndex,
        int EquippedItemClass,
        int Effect_1,
        int Effect_2,
        int EffectDieSides_2,
        int EffectBasePoints_2,
        int ImplicitTargetA_1,
        int ImplicitTargetA_2,
        int EffectAura_1,
        int EffectAura_2,
        int EffectAura_3,
        int EffectMiscValue_1,
        int SpellVisualID_1,
        int SpellIconID,
        string Name_Lang_enUS,
        int Name_Lang_Mask,
        int NameSubtext_Lang_Mask,
        string Description_Lang_enUS,
        int Description_Lang_Mask,
        string AuraDescription_Lang_enUS,
        int AuraDescription_Lang_Mask,
        int StartRecoveryCategory,
        int EffectChainAmplitude_1,
        int EffectChainAmplitude_2,
        int EffectChainAmplitude_3,
        int SchoolMask
    );
}
