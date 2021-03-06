﻿@Imports GleamTech.ExamplesCore
@Imports GleamTech.Web.Mvc
@Imports GleamTech.DocumentUltimate
@Code
    Dim exampleExplorer = New ExampleExplorer() With {
        .FullViewport = True,
        .NavigationTitle = "DocumentUltimate Examples",
        .VersionTitle = "v" + DocumentUltimateConfiguration.AssemblyInfo.FileVersion.ToString(),
        .Examples = New ExampleBase() {
            New ExampleFolder() With {
                .Title = "Document Viewer",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "DocumentViewer/Overview",
                        .SourceFiles = New String() {"Views/DocumentViewer/Overview.vbhtml", "Controllers/DocumentViewerController.Overview.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Overview.html"
                    },
                    New Example() With {
                        .Title = "Copy protection (DRM)",
                        .Url = "DocumentViewer/Protection",
                        .SourceFiles = New String() {"Views/DocumentViewer/Protection.vbhtml", "Controllers/DocumentViewerController.Protection.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Protection.html"
                    },
                    New Example() With {
                        .Title = "Highlighting keywords",
                        .Url = "DocumentViewer/Highlight",
                        .SourceFiles = New String() {"Views/DocumentViewer/Highlight.vbhtml", "Controllers/DocumentViewerController.Highlight.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Highlight.html"
                    },
                    New Example() With {
                        .Title = "Watermarking pages",
                        .Url = "DocumentViewer/Watermark",
                        .SourceFiles = New String() {"Views/DocumentViewer/Watermark.vbhtml", "Controllers/DocumentViewerController.Watermark.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Watermark.html"
                    },
                    New Example() With {
                        .Title = "Using with a stream",
                        .Url = "DocumentViewer/Stream",
                        .SourceFiles = New String() {"Views/DocumentViewer/Stream.vbhtml", "Controllers/DocumentViewerController.Stream.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Stream.html"
                    },
                    New Example() With {
                        .Title = "Events",
                        .Url = "DocumentViewer/Events",
                        .SourceFiles = New String() {"Views/DocumentViewer/Events.vbhtml", "Controllers/DocumentViewerController.Events.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Events.html"
                    }
                }
            },
            New ExampleFolder() With {
                .Title = "Document Converter",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "DocumentConverter/Overview",
                        .SourceFiles = New String() {"Views/DocumentConverter/Overview.vbhtml", "Controllers/DocumentConverterController.Overview.vb"},
                        .DescriptionFile = "Descriptions/DocumentConverter/Overview.html"
                    },
                    New Example() With {
                        .Title = "Possible conversions",
                        .Url = "DocumentConverter/Possible",
                        .SourceFiles = New String() {"Views/DocumentConverter/Possible.vbhtml", "Controllers/DocumentConverterController.Possible.vb"},
                        .DescriptionFile = "Descriptions/DocumentConverter/Possible.html"
                    }
                }
            }
        },
        .ExampleProjectName = "ASP.NET MVC (VB)",
        .ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))
    }
End Code
<!DOCTYPE html>

<html>
<head>
    <title>DocumentUltimate Examples - ASP.NET MVC (VB)</title>

    @Html.RenderCss(exampleExplorer)
    @Html.RenderJs(exampleExplorer)

</head>
<body>
    @Html.RenderControl(exampleExplorer)
</body>
</html>
