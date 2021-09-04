using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWMountAndPetCreator.Infrastructure.Entities
{
    public record SpellIcon(
        int ID,
        string TextureFilename
    );
}
