using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TransportSystems.Frontend.App.ViewModels.SignUp.Driver;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp.Driver
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

            var set = this.CreateBindingSet<VehicleView, VehicleViewModel>();
            set.Bind(brandsPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Brand);
            set.Bind(brandsPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Brands);
            set.Bind(capacitiesPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Capaticy);
            set.Bind(capacitiesPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Capacities);
            set.Bind(kindsPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Kind);
            set.Bind(kindsPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Kinds);
            set.Bind(TypeLabel).To(vm => vm.TypeLabel);
            set.Bind(TypeTextField).To(vm => vm.Kind);
            set.Bind(BrandLabel).To(vm => vm.BrandLabel);
            set.Bind(BrandTextField).To(vm => vm.Brand);
            set.Bind(MaxTonCapacityLabel).To(vm => vm.MaxTonCapacityLabel);
            set.Bind(MaxTonCapacityTextField).To(vm => vm.Capaticy);
            set.Bind(RegistrationNumberLabel).To(vm => vm.RegistrationNumberLabel);
            set.Bind(RegistrationNumberTextField).To(vm => vm.RegistrationNumber);

            set.Bind(NextButton).For("Title").To(vm => vm.NextButtonText);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
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