using CommunityToolkit.Maui.Views;
using MauiMovies.Models;
using System.Collections.ObjectModel;

namespace MauiMovies;

public partial class GenreListPopup : Popup
{
	private bool _selectionHasChanged = false;
	public GenreListPopup(List<UserGenre> genres)
	{
		InitializeComponent();
		BindingContext = this;
		Genres = new ObservableCollection<UserGenre>(genres);

		ResultWhenUserTapsOutsideOfPopup = _selectionHasChanged;
	}

    public ObservableCollection<UserGenre> Genres { get; set; }

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		_selectionHasChanged = true;
		var selectedItems = e.CurrentSelection;
        foreach (var genre in Genres)
        {
            if(selectedItems.Contains(genre))
			{
				genre.Selected = true;
			} 
			else
			{
				genre.Selected = false;
			}
        }
    }

	public void Button_Clicked(object sender, EventArgs e) => Close(_selectionHasChanged);
}