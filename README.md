# Physics Library

This package acts as a wrapper around Unity's built in physics as well as adding a lot of extra functionality. The biggest goal with this asset is consistency on all levels. The API for 2D should be consistent with the API for 3D, the various functions' signatures should follow a pattern across the entire code-base.

## Adding the package to your Unity project.

Open the package manager in unity by navigating to "Window/Package Manager". Then click the plus icon in the top-left, add package from git URL, and paste [https://github.com/HybelStudio/physics-library.git](https://github.com/HybelStudio/physics-library.git) into the text box, and press Add.

## Usage

If you are doing some raycasts, Simply write `Raycast` or `Raycast2D` depending on if you're in 2D or not, then the type of raycast you wish to do. For basic, single-ray, raycasts you should you `Raycast.Single`, which casts a single Ray until it hits something or until its total distance is reached or `Raycast.Through`, which casts through everything or until its total distance is reached. There is one more 'Primitive' type added in this package which is `Raycast.Bounce`, which bounces of surfaces a specified number of times or until its total distance is reached.

If a raycasting funtion returns a bool, it represent wether it hit something or not. In any other case you get back a collection of RaycastHit(2D) objects.\
The function which return a bool can have an optional 'out' argument that can be used to get the RaycastHit(2D) object.

The more advanced functions have other out parameters, notably the `Raycast.Parallel`, which has an 'out RayLine[]' parameter. A RayLine is an object that holds information about a Ray which can be used to draw debug lines in the editor or anything else you might think of.

Use the DrawRay class to draw rays using `Ray`, `Ray2D`, `RayLine` or `RayLine2D` objects. `RayLine` and `RayLine2D` also has static functions to create them in bulk.

If you are doing some overlaps, Simply write `Overlap` or `Overlap2D` depending on if you're in 2D or not, then the type of overlap you wish to do.

If an overlap funtion returns a bool, it represent wether it overlaps something or not. The NonAlloc returns ints which represent how many items was put into the passed in array. This will never be more than the length of the array. In any other case you get back a collection of Colliders objects.\
The function which return a bool can have an optional 'out' argument that can be used to get any Colliders it overlapped.

The more advanced functions have other out parameters, notably the `Overlap.LineOfBoxes...`, which has an `out BoxOverlap[]` parameter or `Overlap.IterateLineOfBoxes` which can return `IEnumerable<BoxOverlapInfo>` since they can't have out parameters. A `BoxOverlap`, or other 'ShapeOverlap' is an object that holds information about the shape used in the overlap which can be used to draw debug lines in the editor or anything else you might think of.

Use the DrawOverlap class to draw shapes using the 'ShapeOverlap' objects.

## Contributing

**Bug Reports & Feature Requests**

Please use the [issue tracker](https://github.com/HybelStudio/physics-library/issues) to report bugs or file features.

Pull requests are welcome. To begin developing, do this under the assets folder of a Unity project.

```sh
git clone https://github.com/HybelStudio/physics-library.git
```

Then open your Unity project and start developing :D

## License

[CC0](https://creativecommons.org/publicdomain/zero/1.0/)