﻿namespace Splitter.Extensions.JsonSchemas;

public class MenuLayoutSchema
{
    public static string GetJson() => @"{            
            ""$schema"": ""http://json-schema.org/draft-07/schema#"",
            ""title"": ""ScaffoldCategories"",
            ""type"": ""array"",
            ""items"": {
                ""type"": ""object"",
                ""properties"": {
                    ""title"": {
                        ""type"": ""string"",
                        ""minLength"": 1
                    },
                    ""products"": {
                        ""type"": ""array"",
                        ""items"": {
                            ""$ref"": ""#/definitions/ScaffoldProduct""
                        }
                    },
                    ""categories"": {
                        ""type"": ""array"",
                        ""items"": {
                            ""$ref"": ""#/items""
                        }
                    }
                },
                ""required"": [
                    ""title"",
                    ""products"",
                    ""categories""
                ]
            },
            ""definitions"": {
                ""ScaffoldProduct"": {
                    ""type"": ""object"",
                    ""properties"": {
                        ""id"": {
                            ""type"": ""string"",
                            ""format"": ""uuid""
                        },
                        ""name"": {
                            ""type"": ""string"",
                            ""minLength"": 1
                        },
                        ""price"": {
                            ""type"": ""number"",
                            ""minimum"": 0
                        },
                        ""images"": {
                            ""type"": ""array"",
                            ""items"": {
                                ""type"": ""string""
                            }
                        },
                        ""description"": {
                            ""type"": [
                                ""string"",
                                ""null""
                            ]
                        }
                    },
                    ""required"": [
                        ""id"",
                        ""name"",
                        ""price""
                    ]
                }
            }
        }
        ";
}