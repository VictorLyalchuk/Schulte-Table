using System.Windows.Input;

namespace Operation_219
{
    public class ClickButton
    {
        private RelayCommand NewGamesCommand;
        public ICommand NewCMD => NewGamesCommand;

        public ClickButton()
        {
            NewGamesCommand = new RelayCommand((o) => New()/*, (o) => SelectedARGB != null*/);
        }

        public void New()
        {

        }
    }




}
