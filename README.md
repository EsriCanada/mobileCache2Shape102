mobileCache2Shape102
====================

Export Mobile cache to shapefile.

This code is updated for Mobile 10.2 (3581) and compiled as x86 to make it work on 64 bit machines

This MobileCacheTool can extract selected features or features in a specified status (original/added/deleted/modified/current) to a shapefile. Photos saved in raster/blob fields are exported as files.

This version works for ArcGIS Mobile 10.x cache. (other versions are available at http://www.arcgis.com/home/search.html?q=mobile%20cache%20shapefile&t=content)

This version works for ArcGIS Mobile 10.x cache. Other versions are available here:

10.0 at: http://www.arcgis.com/home/item.html?id=30280910f8a1441d8cb962e6225ebd2d

10.1.1 at : https://github.com/EsriCanada/mobileCache2Shape1011

10.2 at: https://github.com/EsriCanada/mobileCache2Shape102

The executables files are in the "Release(ready to use).zip". Just extract the folder inside a folder and launch the .EXE.

If you are a developer:
In Mobile10, esri.arcgis.mobile.dll is not installed to GAC. To run this tool, esri.arcgis.mobile.dll and ESRIMobileCore.dll needs to be in current folder (where the EXE is located).
