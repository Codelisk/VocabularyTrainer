using Prism;
using Prism.Magician;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModule.ViewModels.Base
{
    public class TabInsideVmBase : ReactiveObject, IActiveAware
    {
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set {
                this.RaiseAndSetIfChanged(ref isActive, value);
                RaiseIsActiveChanged();
            }
        }

        public event EventHandler IsActiveChanged;
        public TabInsideVmBase()
        {
        }
        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
            if (IsActive)
            {
                OnAppearing();
            }
            else
            {
                OnDisappearing();
            }
        }
        public virtual void OnDisappearing()
        {

        }
        public virtual void OnAppearing()
        {

        }
    }
}
