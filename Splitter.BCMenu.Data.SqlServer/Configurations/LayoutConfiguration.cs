using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class LayoutConfiguration : IEntityTypeConfiguration<MenuLayout>
{
    public void Configure(EntityTypeBuilder<MenuLayout> builder)
    {
        builder.ToTable("Layouts")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedNever();

        builder.Property(p => p.Layout)
        .HasConversion(
            v => v == null ? null : v.RootElement.GetRawText(),
            v => JsonDocument.Parse(v!, new JsonDocumentOptions { AllowTrailingCommas = true })
        );

        builder.HasData([
            new MenuLayout
            {
                Id = Guid.Parse("ca1988b5-f263-4ba5-8e3f-b5706fed20bc"),
                MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                Layout = JsonDocument.Parse(@"
                [
                    {
                        ""title"": ""Appetizers"",
                        ""products"": [
                            {
                                ""id"": ""10000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""20000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""30000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""40000000-0000-0000-0000-000000000000""
                            }
                        ]
                    },
                    {
                        ""title"": ""Main Courses"",
                        ""products"": [
                            {
                                ""id"": ""11000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""12000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""13000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""14000000-0000-0000-0000-000000000000""
                            }
                        ],
                        ""categories"": [
                        {
                            ""title"": ""Burgers"",
                            ""products"": [
                                {
                                    ""id"": ""50000000-0000-0000-0000-000000000000""
                                },
                                {
                                    ""id"": ""60000000-0000-0000-0000-000000000000""
                                },
                                {
                                    ""id"": ""70000000-0000-0000-0000-000000000000""
                                },
                                {
                                    ""id"": ""80000000-0000-0000-0000-000000000000""
                                },
                                {
                                    ""id"": ""90000000-0000-0000-0000-000000000000""
                                }
                            ]
                        }
                      ]
                    },
                    {
                        ""title"": ""Desserts"",
                        ""products"": [
                            {
                                ""id"": ""21000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""22000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""23000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""24000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""25000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""26000000-0000-0000-0000-000000000000""
                            }
                        ]
                    },
                    {
                        ""title"": ""Drinks"",
                        ""products"": [
                            {
                                ""id"": ""15000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""16000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""17000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""18000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""19000000-0000-0000-0000-000000000000""
                            },
                            {
                                ""id"": ""2A000000-0000-0000-0000-000000000000""
                            }
                        ]
                    }
                ]")
            }
        ]);
    }
}

