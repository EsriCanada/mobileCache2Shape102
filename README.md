mobileCache2Shape102
====================

Export Mobile cache to shapefile.

This code is updated for Mobile 10.2 (3581) and compiled as x86 to make it work on 64 bit machines

This MobileCacheTool can extract selected features or features in a specified status (original/added/deleted/modified/current) to a shapefile. Photos saved in raster/blob fields are exported as files.

This version works for ArcGIS Mobile 10.x cache. (other versions are available at http://www.arcgis.com/home/search.html?q=mobile%20cache%20shapefile&t=content)
This tool relays on ArcGIS Mobile 10.2 runtime and ArcGIS Desktop 10.2.2 runtime (need to have both mobile and desktop installed).
In mobile10, esri.arcgis.mobile.dll is not installed to GAC, to run this tool,  esri.arcgis.mobile.dll and ESRIMobileCore.dll needs to be in current folder (where the EXE is located).
