using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignUp.Driver
{
    public partial class VehicleView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] list = { flexibleSpaceLeft, doneButton };
            toolBar.SetItems(list, false);

            var brandsPicker = new UIPickerView();
            var brandsPickerViewModel = new MvxPickerViewModel(brandsPicker);
            brandsPicker.Model = brandsPickerViewModel;
            brandsPicker.ShowSelectionIndicator = true;
            BrandTextField.InputView = brandsPicker;
            BrandTextField.InputAccessoryView = toolBar;

            var capacitiesPicker = new UIPickerView();
            var capacitiesPickerViewModel = new MvxPickerViewModel(capacitiesPicker);
            capacitiesPicker.Model = capacitiesPickerViewModel;
            capacitiesPicker.ShowSelectionIndicator = false;
            MaxTonCapacityTextField.InputView = capacitiesPicker;
            MaxTonCapacityTextField.InputAccessoryView = toolBar;

            var kindsPicker = new UIPickerView();
            var kindsPickerViewModel = new MvxPickerViewModel(kindsPicker);
            kindsPicker.Model = kindsPickerViewModel;
            kindsPicker.ShowSelectionIndicator = true;
            TypeTextField.InputView = kindsPicker;
            TypeTextField.InputAccessoryView = toolBar;
        }

        [Export("DoneAction")]
        private void DoneProvinceAction()
        {
            BrandTextField.EndEditing(false);
            MaxTonCapacityTextField.EndEditing(false);
            TypeTextField.EndEditing(false);
        }
    }
}