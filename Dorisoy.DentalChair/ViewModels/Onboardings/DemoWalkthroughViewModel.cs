﻿
namespace Dorisoy.DentalChair.ViewModels.Onboardings;
public partial class DemoWalkthroughViewModel : ObservableObject
{
    private INavigation _navigationService;
    private Page _pageService;
    public DemoWalkthroughViewModel(INavigation navigationService, Page pageService)
    {
        _navigationService = navigationService;
        _pageService = pageService;

        Boardings = new ObservableCollection<Boarding>();
        CreateBoardingCollection();
    }

    void CreateBoardingCollection()
    {
        Boardings = new ObservableCollection<Boarding>
        {
            new Boarding
            {
                ImagePath = "walkthrough_01_step.png",
                Title = AppTranslations.StringWalkthroughTitleStep1,
                Subtitle = AppTranslations.StringWalkthroughSubtitleStep1
            },
            new Boarding
            {
                ImagePath = "walkthrough_02_step.png",
                Title = AppTranslations.StringWalkthroughTitleStep2,
                Subtitle = AppTranslations.StringWalkthroughSubtitleStep2
            },
            new Boarding
            {
                ImagePath = "walkthrough_03_step.png",
                Title = AppTranslations.StringWalkthroughTitleStep3,
                Subtitle = AppTranslations.StringWalkthroughSubtitleStep3
            }
        };
    }

    #region Commands

    //[RelayCommand]
    //private async void Skip(object obj)
    //{
    //    await CloseWalkThroughPage();
    //}

    //[RelayCommand]
    //private async void Next(object obj)
    //{
    //    if (ValidateAndUpdatePosition())
    //    {
    //        await CloseWalkThroughPage();
    //    }

    //}

    #endregion

    #region Methods
    private bool ValidateAndUpdatePosition()
    {
        ValidateSelection(Position + 1);
        if (Position >= Boardings.Count - 1)
            return true;
        Position = Position + 1;
        return false;
    }

    private void ValidateSelection(int index)
    {
        if (index <= Boardings.Count - 2)
        {
            IsSkipButtonVisible = true;
            NextButtonText = "NEXT";
        }
        else
        {
            NextButtonText = "FINISH";
            IsSkipButtonVisible = false;
        }
    }



    #endregion

    #region Properties

    [ObservableProperty]
    private ObservableCollection<Boarding> _boardings;

    [ObservableProperty]
    private bool _isSkipButtonVisible = true;

    [ObservableProperty]
    private int _position = 0;

    [ObservableProperty]
    private string _nextButtonText = "NEXT";

    #endregion
}
