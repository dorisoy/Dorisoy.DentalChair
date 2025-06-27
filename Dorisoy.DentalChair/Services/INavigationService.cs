
namespace Dorisoy.DentalChair.Services
{
    public interface INavigationService
    {
        Task NavigateToPageAsync(string pageName);
        void NavigationPage(Page? page);
        void NavigationPage(string pageName);
    }
}