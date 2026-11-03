using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations.UpgradeTo500;

[NopSchemaMigration("2026-10-28 00:00:00", "Product.IsBuyWithRewardEnabled")]
public class BuyWithRewardMigration : ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var productTableName = nameof(Product);
        var columnName = nameof(Product.IsBuyWithRewardEnabled);

        if (!Schema.Table(productTableName).Column(columnName).Exists())
        {
            Alter.Table(productTableName)
                .AddColumn(columnName)
                .AsBoolean()
                .NotNullable()
                .SetExistingRowsTo(false);
        }
    }
}
