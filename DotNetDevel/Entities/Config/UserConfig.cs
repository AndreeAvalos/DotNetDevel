using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetDevel.Entities.Config;

public class UserConfig:IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property( prop => prop.CreatedAt).HasDefaultValueSql("now()");
        TextReader reader = new StreamReader($"./Database/Data/users.csv");
        CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch
                = args => args.Header.ToLower(),
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };
        CsvReader csvReader = new(new CsvParser(reader, csvConfig));
        IEnumerable<UserEntity> records = csvReader.GetRecords<UserEntity>();
        builder.HasData(records);
    }
}