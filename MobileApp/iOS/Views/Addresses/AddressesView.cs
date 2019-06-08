using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TransportSystems.Frontend.App.ViewModels.Address;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.Addresses
{
    public partial class AddressesView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] list = { flexibleSpaceLeft, doneButton };
            toolBar.SetItems(list, false);

            var fromAddressPicker = new UIPickerView();
            var fromAddressPickerViewModel = new MvxPickerViewModel(fromAddressPicker);
            fromAddressPicker.Model = fromAddressPickerViewModel;
            fromAddressPicker.ShowSelectionIndicator = true;
            FromTextField.InputView = fromAddressPicker;
            FromTextField.InputAccessoryView = toolBar;

            var toAddressPicker = new UIPickerView();
            var toAddressPickerViewModel = new MvxPickerViewModel(toAddressPicker);
            toAddressPicker.Model = toAddressPickerViewModel;
            toAddressPicker.ShowSelectionIndicator = false;
            ToTextField.InputView = toAddressPicker;
            ToTextField.InputAccessoryView = toolBar;

            var set = this.CreateBindingSet<AddressesView, AddressesViewModel>();
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }

        [Export("DoneAction")]
        private void DoneProvinceAction()
        {
            FromTextField.EndEditing(false);
            ToTextField.EndEditing(false);
            InputTextField.EndEditing(false);
        }
    }
}