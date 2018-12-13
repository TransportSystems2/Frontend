using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TransportSystems.Frontend.App.ViewModels.Booking;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Booking
{
    public partial class BookingView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            UIBarButtonItem doneButton = new UIBarButtonItem("OK", UIBarButtonItemStyle.Done, this, new ObjCRuntime.Selector("DoneAction"));
            UIBarButtonItem[] list = { flexibleSpaceLeft, doneButton };
            toolBar.SetItems(list, false);

            var cityPicker = new UIPickerView();
            var cityPickerViewModel = new MvxPickerViewModel(cityPicker);
            cityPicker.Model = cityPickerViewModel;
            cityPicker.ShowSelectionIndicator = true;
            CityTextField.InputView = cityPicker;
            CityTextField.InputAccessoryView = toolBar;

            var set = this.CreateBindingSet<BookingView, BookingViewModel>();
            set.Bind(cityPickerViewModel).For(p => p.SelectedItem).To(vm => vm.City);
            set.Bind(cityPickerViewModel).For(p => p.ItemsSource).To(vm => vm.Cities);
            set.Bind(CityTextField).To(vm => vm.City);
            set.Bind(ComissionTextField).To(vm => vm.Comission);
            set.Bind(DegreeOfDifficultyTextField).To(vm => vm.DegreeOfDificulty);
            set.Bind(FeedDistanceValueLabel).To(vm => vm.FeedDistance);
            set.Bind(FeedDurationValueLabel).To(vm => vm.FeedDuration);
            set.Bind(TotalDistanceValueLabel).To(vm => vm.TotalDistance);
            set.Bind(TotalPriceValueLabel).To(vm => vm.TotalPrice);

            set.Bind(DateLabel).To(vm => vm.DateLabel);
            set.Bind(CityLabel).To(vm => vm.CityLabel);
            set.Bind(ComissionLabel).To(vm => vm.ComissionLabel);
            set.Bind(DegreeOfDifficultyLabel).To(vm => vm.DegreeOfDificultyLabel);
            set.Bind(FeedDistanceLabel).To(vm => vm.FeedDistanceLabel);
            set.Bind(TotalDistanceLabel).To(vm => vm.TotalDistanceLabel);
            set.Bind(TotalDistanceLabel).To(vm => vm.TotalDistanceLabel);
            set.Bind(TotalPriceLabel).To(vm => vm.TotalPriceLabel);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }

        [Export("DoneAction")]
        private void DoneProvinceAction()
        {
            CityTextField.EndEditing(false);
        }
    }
}

