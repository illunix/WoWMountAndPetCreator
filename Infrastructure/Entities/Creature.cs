using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWMountAndPetCreator.Infrastructure.Entities
{
    public record Creature(
        int Entry,
        int ModelId1,
        string Name,
        string Subname,
        int MinLevel,
        int MaxLevel,
        int Faction,
        int Speed_Walk,
        int Speed_Run,
        int Scale,
        int BaseVariance,
        int RangeVariance,
        int Unit_Class,
        int Unit_Flags2,
        int Type,
        int HoverHeight,
        int HealthModifier,
        int ManaModifier,
        int ArmorModifier,
        int DamageModifier,
        int ExperienceModifier,
        int MovementId,
        int RegenHealth,
        int Flags_Extra
    );
}
