Step-by-step guide to update the Bridge.NET **.vsix** package with a new release.

## Prerequisites

1. [Visual Studio 2013 SDK](http://go.microsoft.com/?linkid=9832352), or 
2. [Visual Studio 2015](https://msdn.microsoft.com/en-ca/library/mt683786.aspx), the SDK is an option within the Visual Studio Installer

## Step-by-step

1. Clone [bridgedotnet/VSIX](https://github.com/bridgedotnet/VSIX) GitHub repository

2. Update Template project:
   * Open **ProjectTemplates\ClassLibrary\ClassLibrary.vstemplate** file in a text editor
   * Search for `<WizardData>` section
   * Update the Bridge version. Example: `<package id="Bridge" version="1.12.0" />` => `<package id="Bridge" version="1.13.0" />`
   * Save the file
   * Open the **ProjectTemplates\ClassLibrary** folder and .zip its content (**not** the folder itself). You'll have **ProjectTemplates\ClassLibrary\ClassLibrary.zip**.
   * Copy this file into the **ProjectTemplates\Bridge.NET** folder replacing the old file.

3. Download the latest [Bridge NuGet package](https://www.nuget.org/packages/Bridge) (the Download button on the left) as a raw .nupkg file. You'll have a **bridge.[VERSION].nupkg** file where **[VERSION]** is the Bridge version, e.g. **bridge.1.13.0.nupkg**.

4. Open **VSIX\VSIX.sln** in Visual Studio.

5. Expand **Packages** folder in Visual Studio Solution Explorer and rename the outdated **bridge.[VERSION].nupkg** to the new version in Visual Studio Solution Explorer. For example, **bridge.1.12.0.nupkg** => **bridge.1.13.0.nupkg**. FYI: renaming should be done in Visual Studio Solution Explorer to keep all the required Visual Studio settings on the file:
   * Build action: Content
   * Copy to Output directory: Copy always
   * Include in VSIX: True

6. Open **Packages** folder in Windows Explorer and copy the new (freshly downloaded) **bridge.[VERSION].nupkg**, e.g. **bridge.1.13.0.nupkg**, replacing the old one.

8. Go back to **VSIX\VSIX.sln** which is opened in Visual Studio and perform the following steps:
   * Double click **source.extension.vsixmanifest** file which is in the solution root
   * Update **Version** (at the top on the right), e.g. **1.12.0** => **1.13.0**
   * Click the **Assets** menu item (the menu is on the left)
   * Click the item in the list with **bridge.[VERSION].nupkg** and then click the **Edit** button
   * Update **bridge.[VERSION].nupkg** in the **Type** and **Path** fields to the new version, e.g. **bridge.1.12.0.nupkg** => **bridge.1.13.0.nupkg**. Click **Ok**.
   * Ensure the solution build mode is **Release**
   * Build the solution
  
9. Rename **VSIX\bin\Release\Bridge.NET.vsix** in Windows Explorer to **Bridge.NET.[VERSION].vsix**, where **[VERSION]** is the Bridge version, e.g. **Bridge.NET.1.13.0.vsix**

11. Test the new .vsix:
  * Double click file and following instructions for installing.
  * Create a new Bridge project and, a test an issue that has been fixed in the new Bridge release.

12. If the check is successful, .vsix file is ready to be uploaded to Visual Studio Gallery.

13. Commit all changes to GitHub.

## TODO

1. Automate some (or all) of these steps. There are a lot of manual steps. 