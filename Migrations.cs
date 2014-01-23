using Orchard.Data.Migration;

namespace PJS.ReTouch {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("ThemeSettingsRecord", table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<string>("Skin", c => c.WithLength(50).WithDefault(Constants.SkinDefault))
                .Column<bool>("UseHoverMenus")
            );

            return 1;
        }
    }
}