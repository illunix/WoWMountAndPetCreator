using Stylet;

namespace WoWMountAndPetCreator.Pages
{
    public class TaskbarViewModel : Screen
    {
        public MountTabViewModel MountTab { get; private set; }

        public TaskbarViewModel(MountTabViewModel mountTabViewModel)
        {
            MountTab = mountTabViewModel;
        }
    }
}
