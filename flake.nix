{
  description =
    "A Nix-flake-based C# development environment - this only fit with my Intel-base MacBook";

  inputs = { nixpkgs.url = "github:NixOS/nixpkgs/nixpkgs-unstable"; };

  outputs = { self, nixpkgs, ... }:
    let
      system = "x86_64-darwin";
      pkgs = nixpkgs.legacyPackages.${system};
    in {
      devShells.x86_64-darwin.default = pkgs.mkShell rec {
        dotnetPkgs = with pkgs; (with dotnetCorePackages; combinePackages[  
          dotnetCorePackages.sdk_8_0
        ]);

        deps = [dotnetPkgs  ];

        nativeBuildInputs = with pkgs; [
          omnisharp-roslyn
          msbuild
        ] ++ deps;

        shellHook = ''
          echo "hello to csharp dev shell"  

        '';

        DOTNET_ROOT = "${dotnetPkgs}";
        OMNISHARP_PATH =
          "${pkgs.omnisharp-roslyn}/bin/OmniSharp"; # environment variable
      };
    };
}
