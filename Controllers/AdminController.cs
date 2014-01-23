using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.UI.Notify;
using PJS.ReTouch.ViewModels;
using PJS.ReTouch.Services;

namespace PJS.ReTouch.Controllers {
    [ValidateInput(false)]
    public class AdminController : Controller {
        private readonly IThemeSettingsService _settingsService;

        public AdminController(
            IOrchardServices services,
            IThemeSettingsService settingsService) {
            _settingsService = settingsService;
            Services = services;
            T = NullLocalizer.Instance;
        }

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public ActionResult Index() {
            var settings = _settingsService.GetSettings();

            var viewModel = new ThemeSettingsViewModel {
                Skin = settings.Skin,
                UseHoverMenus = settings.UseHoverMenus
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ThemeSettingsViewModel viewModel) {
            if (!Services.Authorizer.Authorize(PJS.ReTouch.Permissions.ManageThemeSettings, T("Couldn't update Theme settings")))
                return new HttpUnauthorizedResult();

            var settings = _settingsService.GetSettings();
            settings.Skin = viewModel.Skin;
            settings.UseHoverMenus = viewModel.UseHoverMenus;

            Services.Notifier.Information(T("Your settings have been saved."));

            return View(viewModel);
        }
    }
}