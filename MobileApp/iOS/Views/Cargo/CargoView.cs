using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TransportSystems.Frontend.App.ViewModels.Cargo;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Cargo
{
    public partial class CargoView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] list = { flexibleSpaceLeft, doneButton };
            toolBar.SetItems(list, false);

            var kindsPicker = new UIPickerView();
            var kindsPickerViewModel = new MvxPickerViewModel(kindsPicker);
            kindsPicker.Model = kindsPickerViewModel;
            kindsPicker.ShowSelectionIndicator = true;
            TypeTextField.InputView = kindsPicker;
            TypeTextField.InputAccessoryView = toolBar;

            var weightPicker = new UIPickerView();
            var weightPickerViewModel = new MvxPickerViewModel(weightPicker);
            weightPicker.Model = weightPickerViewModel;
            weightPicker.ShowSelectionIndicator = false;
            WeightTextField.InputView = weightPicker;
            WeightTextField.InputAccessoryView = toolBar;

            var brandsPicker = new UIPickerView();
            var brandsPickerViewModel = new MvxPickerViewModel(brandsPicker);
            brandsPicker.Model = brandsPickerViewModel;
            brandsPicker.ShowSelectionIndicator = true;
            BrandTextField.InputView = brandsPicker;
            BrandTextField.InputAccessoryView = toolBar;

            var set = this.CreateBindingSet<CargoView, CargoViewModel>();
            set.Bind(kindsPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Kind);
            set.Bind(kindsPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Kinds);
            set.Bind(weightPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Weight);
            set.Bind(weightPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Weights);
            set.Bind(brandsPickerViewModel).For(p => p.SelectedItem).To(vm => vm.Brand);
            set.Bind(brandsPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Brands);
            set.Bind(TypeLabel).To(vm => vm.KindLabel);
            set.Bind(TypeTextField).To(vm => vm.Kind);
            set.Bind(WeightLabel).To(vm => vm.WeightLabel);
            set.Bind(WeightTextField).To(vm => vm.Weight);
            set.Bind(BrandLabel).To(vm => vm.BrandLabel);
            set.Bind(BrandTextField).To(vm => vm.Brand);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }

        [Export("DoneAction")]
        private void DoneProvinceAction()
        {
            TypeTextField.EndEditing(false);
            WeightTextField.EndEditing(false);
            BrandTextField.EndEditing(false);
        }
    }
}