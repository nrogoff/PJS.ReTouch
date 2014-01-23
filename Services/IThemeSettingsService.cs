using PJS.ReTouch.Models;
using Orchard;

namespace PJS.ReTouch.Services {
    public interface IThemeSettingsService : IDependency {
        ThemeSettingsRecord GetSettings();
    }
}