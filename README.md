# ![DocumentUltimate Logo](documentultimate-logo.png) DocumentUltimate: ASP.NET Document Viewer
DocumentUltimate is an ASP.NET Document Viewer and Converter which supports both ASP.NET MVC and ASP.NET WebForms web applications/web sites. DocumentUltimate can also be used with .NET desktop applications for conversion between several document formats.

- View almost any document type (70+ file formats, including PDF & Microsoft Office).

- HTML5 Zero-footprint viewer.

- Convert between document types.

![ASP.NET Document Viewer](documentultimate.png)

**Note:** This project contains a fully working version of the product, however without a license key it will run in trial mode. For more information, please see [DocumentUltimate: ASP.NET Document Viewer](http://www.gleamtech.com/documentultimate) product page.

### To use DocumentUltimate in an ASP.NET MVC Project, do the following in Visual Studio:

1.  Add references to DocumentUltimate assemblies. There are two ways to perform this:

    -   Add reference to **GleamTech.Core.dll** and **GleamTech.DocumentUltimate.dll** found in "Bin" folder of DocumentUltimate-vX.X.X.X.zip package which you already downloaded and extracted.

    -   Or install NuGet package and add references automatically via NuGet Package Manager in Visual Studio: 
        Go to **Tools -> NuGet Package Manager -> Package Manager Console** and run this command:

			`Install-Package DocumentUltimate -Source https://get.gleamtech.com/nuget/default/`

		If you prefer using the user interface when working with NuGet, you can also install the package this way:
		
			-  GleamTech has its own NuGet feed so first you need to add this feed to be able to find GleamTech's packages. 
			    Go to **Tools -> NuGet Package Manager -> Package Manager Settings** and then click the **+** button to add a 
			    new package source. Enter `GleamTech` in **Name** field and `https://get.gleamtech.com/nuget/default/` 
			    in **Source** field and click **OK**.
			    
			-  Go to **Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution**, select `GleamTech` or `All` 
			   in the Package source dropdown on the top right. Now enter `DocumentUltimate` in the search field, 
			   and click **Install** button on the found package.

2.  Set DocumentUltimate's global configuration. For example, you may want to set the license key and the cache path. Insert some of the following lines (if overriding a default value is required) into the ```Application_Start``` method of your **Global.asax.cs**:

    ```
    //Set this property only if you have a valid license key, otherwise do not
    //set it so DocumentUltimate runs in trial mode.
    DocumentUltimateConfiguration.Current.LicenseKey = "QQJDJLJP34...";

    //The default CachePath value is "~/App_Data/DocumentCache"
    //Both virtual and physical paths are allowed.
    DocumentUltimateWebConfiguration.Current.CachePath = "~/App_Data/DocumentCache";
    ```

    Alternatively you can specify the configuration in ```<appSettings>``` tag of your Web.config.

    ```
    <appSettings>
      <add key="DocumentUltimate:LicenseKey" value="QQJDJLJP34..." />
      <add key="DocumentUltimateWeb:CachePath" value="~/App_Data/DocumentCache" />
    </appSettings>
    ```

    As you would notice, `DocumentUltimate:` prefix maps to `DocumentUltimateConfiguration.Current` and `DocumentUltimateWeb:` prefix maps to ```DocumentUltimateWebConfiguration.Current```.

3.  Open one of your View pages (eg. Index.cshtml) and at the top of your page add the necessary namespaces:

    ```
    @using GleamTech.Web.Mvc
    @using GleamTech.DocumentUltimate.Web
    ```

    Alternatively you can add the namespaces globally in **Views/web.config** to avoid adding namespaces in your pages every time:

    ```
    <system.web.webPages.razor>
      <pages pageBaseType="System.Web.Mvc.WebViewPage">
        <namespaces>
          .
          .
          .
          <add namespace="GleamTech.Web.Mvc" />
          <add namespace="GleamTech.DocumentUltimate.Web" />
        </namespaces>
      </pages>
    </system.web.webPages.razor>
    ```

    Now in your page insert these lines:

    ```
    @{
        var documentViewer = new DocumentViewer 
        {
            Width = 800,
            Height = 600,
            Document = "~/Documents/Document.docx"
        };
    }              
    <html> 
      <head> 
        @Html.RenderCss(documentViewer) 
        @Html.RenderJs(documentViewer)
      </head> 
      <body> 
        @Html.RenderControl(documentViewer) 
      </body> 
    </html>
    ```

    This will render a DocumentViewer control in the page which loads and displays the source document "~/Documents/Document.docx". Upon first view, internally DocumentViewer will convert the source document to PDF (used for "Download as Pdf" and also for next conversion step) and then to XPZ (a special web-friendly format which DocumentViewer uses to actually render documents in the browser). So in this case the user will see "please wait awhile..." message in the viewer for a few seconds. These generated PDF and XPZ files will be cached and upon consecutive page views, the document will be served directly from the cache so the user will see the document instantly on second viewing. When you modify the source document, the cached files are invalidated so your original document and the corresponding cached files are always synced automatically. Note that it's also possible to pre-cache documents via `DocumentCache.PreCacheDocument` method (e.g. when your user uploads a document).

### To use DocumentUltimate in an ASP.NET WebForms Project, do the following in Visual Studio:

1.  Add references to DocumentUltimate assemblies. There are two ways to perform this:

    -   Add reference to **GleamTech.Core.dll** and **GleamTech.DocumentUltimate.dll** found in "Bin" folder of DocumentUltimate-vX.X.X.X.zip package which you already downloaded and extracted.

    -   Or install NuGet package and add references automatically via NuGet Package Manager in Visual Studio: 
        Go to **Tools -> NuGet Package Manager -> Package Manager Console** and run this command:

			`Install-Package DocumentUltimate -Source https://get.gleamtech.com/nuget/default/`

		If you prefer using the user interface when working with NuGet, you can also install the package this way:
		
			-  GleamTech has its own NuGet feed so first you need to add this feed to be able to find GleamTech's packages. 
			    Go to **Tools -> NuGet Package Manager -> Package Manager Settings** and then click the **+** button to add a 
			    new package source. Enter `GleamTech` in **Name** field and `https://get.gleamtech.com/nuget/default/` 
			    in **Source** field and click **OK**.
			    
			-  Go to **Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution**, select `GleamTech` or `All` 
			   in the Package source dropdown on the top right. Now enter `DocumentUltimate` in the search field, 
			   and click **Install** button on the found package.

2.  Set DocumentUltimate's global configuration. For example, you may want to set the license key and the cache path. Insert some of the following lines (if overriding a default value is required) into the ```Application_Start``` method of your **Global.asax.cs**:

    ```
    //Set this property only if you have a valid license key, otherwise do not
    //set it so DocumentUltimate runs in trial mode.
    DocumentUltimateConfiguration.Current.LicenseKey = "QQJDJLJP34...";

    //The default CachePath value is "~/App_Data/DocumentCache"
    //Both virtual and physical paths are allowed.
    DocumentUltimateWebConfiguration.Current.CachePath = "~/App_Data/DocumentCache";
    ```

    Alternatively you can specify the configuration in ```<appSettings>``` tag of your Web.config.

    ```
    <appSettings>
      <add key="DocumentUltimate:LicenseKey" value="QQJDJLJP34..." />
      <add key="DocumentUltimateWeb:CachePath" value="~/App_Data/DocumentCache" />
    </appSettings>
    ```

    As you would notice, `DocumentUltimate:` prefix maps to `DocumentUltimateConfiguration.Current` and `DocumentUltimateWeb:` prefix maps to ```DocumentUltimateWebConfiguration.Current```.

3.  Open one of your pages (eg. Default.aspx) and at the top of your page add add the necessary namespaces:

    ```
    <%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.Web" Assembly="GleamTech.DocumentUltimate" %>
    ```

    Alternatively you can add the namespaces globally in **Web.config** to avoid adding namespaces in your pages every time:

    ```
    <system.web>
      <pages>
        <controls>
          .
          .
          .
          <add tagPrefix="GleamTech" namespace="GleamTech.DocumentUltimate.Web" assembly="GleamTech.DocumentUltimate" />
        </controls>
      </pages>
    </system.web>
    ```

    Now in your page insert these lines:

    ```
    <GleamTech:DocumentViewer runat="server" 
        Width="800" 
        Height="600" 
        Document="~/Documents/Document.docx" />
    ```

    This will render a DocumentViewer control in the page which loads and displays the source document "~/Documents/Document.docx". Upon first view, internally DocumentViewer will convert the source document to PDF (used for "Download as Pdf" and also for next conversion step) and then to XPZ (a special web-friendly format which DocumentViewer uses to actually render documents in the browser). So in this case the user will see "please wait awhile..." message in the viewer for a few seconds. These generated PDF and XPZ files will be cached and upon consecutive page views, the document will be served directly from the cache so the user will see the document instantly on second viewing. When you modify the source document, the cached files are invalidated so your original document and the corresponding cached files are always synced automatically. Note that it's also possible to pre-cache documents via `DocumentCache.PreCacheDocument` method (e.g. when your user uploads a document).
