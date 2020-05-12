# PhotoShop

## Summary:
A photoshop program implementing FFT, Convolution and other image processing techniques.
Perfoms image decomposition into user definied number of most common colours within the picture.

## Requirments:
* Currently only supports a palette up to 18
* Currently works optimaly for pictured under 30KB for full K
  * If you use images >= 20-30kb make sure your choice of K is under 10-12 for optimal usage
* Note done button is not supported at the moment in gen palette window

## To use download exe from link:
[PhotoShop](https://github.com/KrishnaSolo/PhotoShop/blob/master/bin/Release/PhotoShop.exe)

## Demo:
![Image of Demo](https://github.com/KrishnaSolo/PhotoShop/blob/master/Demo.png)

## Features:
- [x] Added convolution image processing (Blur Filter)
- [x] Added convolution image processing (Sharp Filter)
- [x] Added violet filter
- [x] Added image palette gen feature using K-means
- [ ] Updated K-mean to K-means++ for better results
- [ ] Added Multithreading to support larger photos
- [ ] Updated UI using YAML
