This is a step-by-step guide to update the .vsix package to a new Bridge version for uploading to Visual Studio gallery.

## Prerequisites

1. [Visual Studio 2013 SDK](http://go.microsoft.com/?linkid=9832352), or 
2. [Visual Studio 2015](https://msdn.microsoft.com/en-ca/library/mt683786.aspx), the SDK is an option within the Visual Studio Installer, and
3. [7-zip](http://www.7-zip.org/download.html)

## Step-by-step

1. Clone the [bridgedotnet/VSIX](https://github.com/bridgedotnet/VSIX) GitHub repository

2. Update the template project:
   * Open `ProjectTemplates\ClassLibrary\ClassLibrary.vstemplate` file in any text editor
   * Search for `<WizardData>` section
   * Update the Bridge version. E.g.: 
     * `<package id="Bridge" version="1.12.1" />` => 
     * `<package id="Bridge" version="1.13.0" />`
   * Save the file
   * Open the `ProjectTemplates\ClassLibrary` folder and zip its content (**not** the folder itself). You'll have `ProjectTemplates\ClassLibrary\ClassLibrary.zip`.
   * Cut this file and paste into the `ProjectTemplates\Bridge.NET` folder replacing the old file.

3. Download the latest [Bridge NuGet package](https://www.nuget.org/packages/Bridge) (the Download button on the left) as a raw .nupkg file. You'll have a `bridge.X.nupkg` file where `X` - the Bridge version, e.g. `bridge.1.13.0.nupkg`.

4. Open `VSIX\VSIX.sln` in Visual Studio

5. Expand `Packages` folder in Visual Studio Solution Explorer and rename the outdated `bridge.X.nupkg` to the new version in Visual Studio Solution Explorer. For example, `bridge.1.12.1.nupkg` => `bridge.1.13.0.nupkg`. FYI: renaming should be done in Visual Studio Solution Explorer to keep all the required Visual Studio settings on the file:
   * Build action: Content
   * Copy to Output directory: Copy always
   * Include in VSIX: True

6. Open `Packages` in Windows Explorer

7. Put the new (freshly downloaded) `bridge.X.nupkg`, e.g. `bridge.1.13.0.nupkg`, replacing the old one.

8. Go back to `VSIX\VSIX.sln` which is opened in Visual Studio. All these actions should be done in Visual Studio:
   * Double click `source.extension.vsixmanifest` file which is in the solution root
   * Update **Version** (at the top on the right), e.g. `1.12.1` => `1.13.0`
   * Click the **Assets** menu item (the menu is on the left)
   * Click the item in the list with `bridge.X.nupkg` and then click the **Edit** button
   * Update `bridge.X.nupkg` in the **Type** and **Path** fields to the new version, e.g. `bridge.1.12.1.nupkg` => `bridge.1.13.0.nupkg`. Click **Ok**.
   * Double click `Resources\LICENSE.txt` in Solution Explorer
   * Update the version in the first line, e.g. `1.12.1` => `1.13.0`.
   * Ensure the solution build mode is **Release**
   * Build the solution
  
9. Take `VSIX\bin\Release\Bridge.NET.vsix` in Windows Explorer

10. Rename `Bridge.NET.vsix` to `Bridge.NET.X.vsix`, where `X` - the Bridge version, e.g. `Bridge.NET.1.13.0.vsix`

11. Ensure the .vsix file is okay:
  * Try to install .vsix to your Visual studio - double click the file and follow the instructions
  * Try to create a Bridge project and, for example, test some issue that has been fixed in the new Bridge release

12. If the check is successful, then the .vsix file is ready to be uploaded to Visual Studio Gallery

13. Commit all the changes to GitHub