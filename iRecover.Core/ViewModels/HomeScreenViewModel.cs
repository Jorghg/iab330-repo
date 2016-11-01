using MvvmCross.Core.ViewModels;

namespace iRecover.Core.ViewModels
{
    public class HomeScreenViewModel
        : MvxViewModel
    {
        private string _name = "Hello MvvmCross";
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value != _name)
                {
                    _name = value;
                    RaisePropertyChanged(() => Name);
                }
            }

        }
    }



} // END home