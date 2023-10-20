using CommunityToolkit.Maui.Views;
using MauiMovies.Models;

namespace MauiMovies;

public partial class MovieDetailsPopup : Popup
{
	public MovieDetailsPopup(MovieResult movie, List<Genre> genres)
	{
		Size = new Size(600,600);
		Title = movie.title;
		Description = movie.overview;
		PosterUrl = movie.poster_path;
		Rating = movie.vote_average;

		foreach (var id in movie.genre_ids) {
			var selection = genres.Where(a => a.id == id).Select(a => a.name).FirstOrDefault();
			if(!string.IsNullOrEmpty(selection))
			{
				Genres.Add(selection);
			}
		}
		BindingContext = this;
		InitializeComponent();
	}

    public string Title { get; set; }

	public string Description { get; set; }

	public string PosterUrl { get; set; }

	public List<string> Genres { get; set; } = new();

    public double Rating { get; set; }
}