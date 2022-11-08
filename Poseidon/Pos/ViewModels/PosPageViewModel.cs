using System;
using System.Windows.Input;
using Poseidon.ViewModels;
using Xamarin.Forms;

namespace Poseidon.Pos.ViewModels
{
    public class PosPageViewModel : ProductViewModel
    {
        public PosPageViewModel() : base()
        {
        }

        public ICommand TapProductCommandAsync =>
            new Command(async () =>
            {
                
            }
        );
    }
}

