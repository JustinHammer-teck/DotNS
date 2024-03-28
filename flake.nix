{
  description =
    "A Nix-flake-based C# development environment - this only fit with my Intel-base MacBook";

  inputs = { nixpkgs.url = "github:NixOS/nixpkgs/nixpkgs-unstable"; };

  outputs = { self, nixpkgs, ... }:
    let
      system = "x86_64-darwin";
      pkgs = nixpkgs.legacyPackages.${system};
    in {
      devShells.x86_64-darwin.default = pkgs.mkShell {
        nativeBuildInputs = with pkgs; [
          dotnet-sdk_8
          omnisharp-roslyn
          msbuild
        ];

        shellHook = ''
          echo "hello to csharp dev shell"  
          ${pkgs.dotnet-sdk_8}/bin/dotnet --version
        '';

        OMNISHARP_PATH =
          "${pkgs.omnisharp-roslyn}/bin/OmniSharp"; # environment variable
      };
    };
}
