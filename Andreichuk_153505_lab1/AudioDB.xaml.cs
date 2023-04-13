using Andreichuk_153505_lab1.Entities;
using Andreichuk_153505_lab1.Services;
namespace Andreichuk_153505_lab1;

public partial class AudioDB : ContentPage
{
    private IDbService DbService { get; init; }

    public List<Author> AuthorsList { set; get; }

    public List<Songs> SongsList { set; get; }

    public AudioDB(IDbService dbService)
	{
        DbService = dbService;
        DbService.Init();
        BindingContext = this;
        InitializeComponent();
	}

    public void OnLoaded(object sender, EventArgs e)
    {
        AuthorsList = DbService.GetAllAuthors().ToList();
        picker.ItemsSource = AuthorsList.ToList();
       
    }

    void OnPicker(object sender, EventArgs e)
    {

        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Console.WriteLine(selectedIndex.ToString());


        if (selectedIndex != -1)
        {
            SongsList = (DbService.GetAuthorsSongs((picker.SelectedItem as Author).Id)).ToList();
            listView.ItemsSource = SongsList;
        }
    }
}