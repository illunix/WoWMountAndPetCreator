using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWMountAndPetCreator.Infrastructure.Entities
{
    public record Item(
        int Entry,
        int Class,
        int SubClass,
        int SoundOverrideSubclass,
        string Name,
        int DisplayId,
        int Quality,
        int AllowableClass,
        int AllowableRace,
        int SpellId_1,
        int SpellCharges_1,
        int SpellCooldown_1,
        int SpellCategory_1,
        int SpellCategoryCooldown_1,
        int SpellId_2,
        int SpellTrigger_2,
        int Bonding,
        string Description,
        int Material
    );
}
