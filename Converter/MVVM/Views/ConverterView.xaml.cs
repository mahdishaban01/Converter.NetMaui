using Converter.MVVM.ViewModels;

namespace Converter.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		//BindingContext = new ConverterViewModel();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var viewModel =
             (ConverterViewModel)BindingContext;
        viewModel.Convert();
    }
}