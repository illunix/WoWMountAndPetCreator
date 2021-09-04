using Stylet;

namespace WoWMountAndPetCreator.Pages
{
    public class ShellViewModel : Screen
    {
        public TaskbarViewModel Taskbar { get; private set; }

        public ShellViewModel(TaskbarViewModel taskbarViewModel)
            => Taskbar = taskbarViewModel;
    }
}
