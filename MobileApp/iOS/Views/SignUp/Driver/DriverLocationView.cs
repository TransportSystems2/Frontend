using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp.Driver
{
    public partial class DriverLocationView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] list = { flexibleSpaceLeft, doneButton };
            toolBar.SetItems(list, false);

            var provincePicker = new UIPickerView();
            var provincePickerViewModel = new MvxPickerViewModel(provincePicker);
            provincePicker.Model = provincePickerViewModel;
            provincePicker.ShowSelectionIndicator = true;
            ProvinceTextField.InputView = provincePicker;
            ProvinceTextField.InputAccessoryView = toolBar;

            var cityPicker = new UIPickerView();
            var cityPickerViewModel = new MvxPickerViewModel(cityPicker);
            cityPicker.Model = cityPickerViewModel;
            cityPicker.ShowSelectionIndicator = false;
            CityTextField.InputView = cityPicker;
            CityTextField.InputAccessoryView = toolBar;

            var regionPicker = new UIPickerView();
            var regionPickerViewModel = new MvxPickerViewModel(regionPicker);
            regionPicker.Model = regionPickerViewModel;
            regionPicker.ShowSelectionIndicator = true;
            RegionTextField.InputView = regionPicker;
            RegionTextField.InputAccessoryView = toolBar;
        }

        [Export("DoneAction")]
        private void DoneProvinceAction()
        {
            ProvinceTextField.EndEditing(false);
            CityTextField.EndEditing(false);
            RegionTextField.EndEditing(false);
        }
    }
}

