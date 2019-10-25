# How to contribute

The main branch is `master`. No one should directly commit here, this is a stable branch. The main development process will be in `develop` branch.

To contribute to a project, you should create your own branch **from latest develop**.

When you are ready to publish your commits, start a pull request from your branch to `develop`. It's better to name your branch `feature/<feature_name>`.

## When you starting a pull request
- Make sure that there is no conflicts between your branch and `develop`
- Make sure that you pulled all recent changes from `develop` to your branch

### Code style

Your C# code have to correspond to the standard code conventions: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/inside-a-program/coding-conventions.

### Unity resources folders

You should place all project resources to the dedicated directories inside of project. It's prohibited to use absolute paths in a project.
Project directory tree should be as follows:
```
- Animations/
- Fonts/
- Materials/
- Prefabs/
- Resources/
- Scenes/
- Scripts/
- Sprites/
| - Managers/
| - Preload/
| - <others...>
- UI/
```


### Unity Scenes

Every contributor should have his own scene for avoiding the conflicts.

Project should have `__preload` scene to keep all managers here.
