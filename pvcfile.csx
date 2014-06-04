pvc.Task("nuget-push", () => {
    pvc.Source("src/Pvc.AngularPreMinifier.csproj")
       .Pipe(new PvcNuGetPack(
            createSymbolsPackage: true
       ))
       .Pipe(new PvcNuGetPush());
});
