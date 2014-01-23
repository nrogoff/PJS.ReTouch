namespace PJS.ReTouch.Models {
    public class ThemeSettingsRecord {
        public ThemeSettingsRecord() {
            this.Skin = Constants.SkinDefault;
        }

        public virtual int Id { get; set; }
        public virtual string Skin { get; set; }
        public virtual bool UseHoverMenus { get; set; }
    }
}